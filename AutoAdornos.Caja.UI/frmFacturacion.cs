using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAdornos.Caja.UI
{
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                //var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();

                var listaProductos = servicioIntegracion.ListarProductos();

                using (var dbLocal = new AutoAdornos_CajaLocalEntities())
                {
                    dbLocal.Database.ExecuteSqlCommand("TRUNCATE TABLE tblProductoCache");

                    foreach (var prod in listaProductos)
                    {
                        var nuevoProductoLocal = new tblProductoCache();
                        nuevoProductoLocal.IdProducto = prod.IdProducto;
                        nuevoProductoLocal.Nombre = prod.Nombre;
                        nuevoProductoLocal.Precio = prod.Precio;
                        nuevoProductoLocal.Stock = prod.Stock;

                        dbLocal.tblProductoCaches.Add(nuevoProductoLocal);
                    }

                    dbLocal.SaveChanges();
                }

                MessageBox.Show("Catálogo de productos sincronizado exitosamente", "Sincronización OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si no hay internet o el servidor está apagado, caerá aquí
                MessageBox.Show("Error al sincronizar con el servidor: " + ex.Message, "Modo Offline", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */
        }
    }
}
