using Integracion.Sincronizador.CoreReferencia;
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
                            string idCliente = reader["IdCliente"].ToString();
                            decimal total = (decimal)reader["Total"];
                            string canal = reader["CanalVenta"].ToString();

                            Console.WriteLine($"[INFO] Sincronizando Factura Local #{idLocal} del cliente {idCliente}...");

                            try
                            {
                                var clienteCore = new CoreServiceSoapClient();

                                bool resultado = clienteCore.RecibirFacturaOffline(
                                    idLocal.ToString(),
                                    idCliente,
                                    total,
                                    canal
                                );

                                if (resultado)
                                {
                                    Console.WriteLine($"[EXITO] Factura #{idLocal} guardada en CORE.");
                                    BorrarFacturaDeCola(idLocal);
                                }
                                else
                                {
                                    Console.WriteLine($"[ADVERTENCIA] El CORE rechazó la factura #{idLocal}. Se queda en cola.");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Si el CORE está apagado, entrará aquí
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
                try
                {
                    conn.Open();
                    string sqlDetalle = "DELETE FROM Cola_tblFacturaDetalle WHERE IdFacturaLocal = @id";
                    using (var cmd = new SqlCommand(sqlDetalle, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idLocal);
                        cmd.ExecuteNonQuery();
                    }

                    // Luego la factura
                    string sqlFactura = "DELETE FROM Cola_tblFactura WHERE IdFacturaLocal = @id";
                    using (var cmd = new SqlCommand(sqlFactura, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idLocal);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] No se pudo limpiar la cola para ID {idLocal}: {ex.Message}");
                }
            }
        }
    }
}