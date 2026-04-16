using Integracion.Sincronizador.ReferenciaCore; 
using System;
using System.Data.SqlClient;
using System.Threading;

namespace Integracion.Sincronizador
{
    class Program
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_Integracion;Integrated Security=True;";

        static void Main(string[] args)
        {
            Console.WriteLine(">>> SINCRONIZADOR AUTOADORNOS ACTIVADO <<<");
            Console.WriteLine("Escaneando facturas pendientes cada 15 segundos...\n");

            while (true)
            {
                ProcesarColaFacturas();
                Thread.Sleep(15000);
            }
        }

        static void ProcesarColaFacturas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "SELECT IdFacturaLocal, IdCliente, Total, CanalVenta FROM Cola_tblFactura";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idLocal = (int)reader["IdFacturaLocal"];
                            decimal total = (decimal)reader["Total"];
                            string canal = reader["CanalVenta"].ToString();

                            Console.WriteLine($"[INFO] Sincronizando Factura Local #{idLocal} de {canal}...");

                            try
                            {
                                // 2. Llamamos al CORE
                                var clienteCore = new CoreServiceSoapClient();

                                bool resultado = clienteCore.RecibirFacturaSincronizada(idLocal, total, canal);

                                if (resultado)
                                {
                                    Console.WriteLine($"[EXITO] Factura #{idLocal} guardada en CORE.");
                                    // 3. Borramos de la cola para no duplicar
                                    BorrarFacturaDeCola(idLocal);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[FALLO] CORE inaccesible para factura #{idLocal}. Reintentando luego...");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión con Integración: " + ex.Message);
                }
            }
        }

        static void BorrarFacturaDeCola(int idLocal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Primero borramos detalles (por integridad referencial)
                string sqlDetalle = "DELETE FROM Cola_tblFacturaDetalle WHERE IdFacturaLocal = @id";
                // Luego la factura
                string sqlFactura = "DELETE FROM Cola_tblFactura WHERE IdFacturaLocal = @id";

                conn.Open();
                using (var cmd = new SqlCommand(sqlDetalle, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idLocal);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SqlCommand(sqlFactura, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idLocal);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}