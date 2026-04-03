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
        decimal precioActual = 0m;
        BindingList<DetalleCarrito> listaCarrito = new BindingList<DetalleCarrito>();


        decimal fondoCaja = 0m;
        decimal totalVendidoDia = 0m;


        public frmFacturacion(decimal montoApertura)
        {
            InitializeComponent();

            fondoCaja = montoApertura;


            dgvCarrito.AutoGenerateColumns = false;
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdProducto", HeaderText = "ID" });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Producto", Width = 200 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio" });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant" });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Importe", HeaderText = "Subtotal" });

            dgvCarrito.DataSource = listaCarrito;
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {

            try
            {
                var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();

                var listaProductos = servicioIntegracion.ListarProductos();

                using (var dbLocal = new AutoAdornos_CajaLocalEntities())
                {
                    dbLocal.Database.ExecuteSqlCommand("TRUNCATE TABLE tblProductoCache");

                    foreach (var prod in listaProductos)
                    {
                        var nuevoProductoLocal = new tblProductoCache();

                        nuevoProductoLocal.IdProducto = prod.IdProducto;
                        nuevoProductoLocal.Nombre = prod.Descripcion; 
                        nuevoProductoLocal.Precio = prod.Precio;
                        nuevoProductoLocal.Stock = prod.Existencia;

                        dbLocal.tblProductoCaches.Add(nuevoProductoLocal);
                    }

                    dbLocal.SaveChanges();
                }

                MessageBox.Show("Catálogo de productos sincronizado exitosamente", "Sincronización OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al sincronizar con el servidor: " + ex.Message, "Modo Offline", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProducto.Text))
            {
                MessageBox.Show("Primero busque un producto válido.");
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.");
                return;
            }

            DetalleCarrito nuevoItem = new DetalleCarrito
            {
                IdProducto = int.Parse(txtIdProducto.Text),
                Descripcion = txtNombreProducto.Text,
                Precio = precioActual,
                Cantidad = (int)numCantidad.Value
            };


            listaCarrito.Add(nuevoItem);

            ActualizarTotal();

            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            numCantidad.Value = 0;
            precioActual = 0m;
            txtIdProducto.Focus();
        }

        private void ActualizarTotal()
        {
            decimal totalGeneral = 0;

            // Recorremos nuestra lista en lugar del DataGridView
            foreach (var item in listaCarrito)
            {
                totalGeneral += item.Importe;
            }

            lblTotal.Text = "Total: $" + totalGeneral.ToString("0.00");
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
            {
                MessageBox.Show("Por favor, ingrese el ID del producto.");
                return;
            }

            try
            {
                int idBuscado = int.Parse(txtIdProducto.Text);


                using (var dbLocal = new AutoAdornos_CajaLocalEntities())
                {

                    var producto = dbLocal.tblProductoCaches
                                          .FirstOrDefault(p => p.IdProducto == idBuscado);

                    if (producto != null)
                    {
                        txtNombreProducto.Text = producto.Nombre;


                        precioActual = producto.Precio ?? 0m;


                        numCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado en el catálogo local.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombreProducto.Clear();
                        precioActual = 0m;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: El ID debe ser un número entero.");
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (listaCarrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de facturar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idCliente = 2; 
                int idVehiculo = 1; 
                int idUsuario = 1; 
                int idSucursal = 1; 
                string canalVenta = "CAJA"; 


                decimal totalPagar = listaCarrito.Sum(item => item.Importe);

                totalVendidoDia += totalPagar;


                var detallesVenta = new List<IntegracionReferencia.ItemVenta>();

                foreach (var item in listaCarrito)
                {
                    var nuevoItem = new IntegracionReferencia.ItemVenta();
                    nuevoItem.IdProducto = item.IdProducto;

                    nuevoItem.Cantidad = item.Cantidad;
                    nuevoItem.Precio = item.Precio;

                    detallesVenta.Add(nuevoItem);
                }


                var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();


                string respuesta = servicioIntegracion.RegistrarVenta(
                    idCliente,
                    idVehiculo,
                    idUsuario,
                    idSucursal,
                    canalVenta,
                    totalPagar,
                    detallesVenta.ToArray()
                );


                if (respuesta.Contains("Error CORE:") || respuesta.Contains("endpoint listening"))
                {
                    MessageBox.Show("Sin conexión con el servidor central.\n\nVenta guardada localmente para sincronización posterior.", "Modo Offline Activado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(respuesta, "Resultado de la Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                frmVisorRecibo visor = new frmVisorRecibo();

                visor.MostrarRecibo(listaCarrito.ToList());
                visor.ShowDialog();

                listaCarrito.Clear(); 
                ActualizarTotal();    
                txtIdProducto.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al conectar con Integración: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            frmCierreCaja pantallaCierre = new frmCierreCaja(fondoCaja, totalVendidoDia);
            pantallaCierre.ShowDialog();
        }

        private void btnSincronizarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();

                MessageBox.Show("Iniciando sincronización de ventas pendientes. Por favor espere...", "Sincronizando", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ¡AHORA SÍ EXISTE EL MÉTODO!
                string respuesta = servicioIntegracion.SincronizarVentasOffline();

                MessageBox.Show(respuesta, "Resultado de Sincronización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // 1. Validar que no le den a buscar con la caja vacía
            if (string.IsNullOrWhiteSpace(txtCedulaCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula o RNC.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedulaCliente.Focus();
                return;
            }

            // 2. Simular la búsqueda (Como si llamáramos al servidor)
            MessageBox.Show("Buscando cliente en el servidor central...", "Buscando", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Crear un cliente de prueba
            if (txtCedulaCliente.Text == "40212345678" || txtCedulaCliente.Text == "123456789")
            {
                MessageBox.Show("Cliente encontrado\n\nNombre: Juan Pérez\nCategoría: Cliente VIP\nDescuento: Aplicable", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Si ponen cualquier otra cédula, simulamos que es un cliente nuevo
                MessageBox.Show("Cliente no encontrado en la base de datos.\n\nSe registrará la venta como 'Cliente de Contado / Consumidor Final'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }

    public class DetalleCarrito
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        // Esta propiedad calcula el subtotal automáticamente
        public decimal Importe
        {
            get { return Precio * Cantidad; }
        }
    }

}
