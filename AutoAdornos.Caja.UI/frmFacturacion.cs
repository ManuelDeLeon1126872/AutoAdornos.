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
        int stockActual = 0;

        public static List<DetalleCarrito> VentasDelTurno = new List<DetalleCarrito>();
        BindingList<DetalleCarrito> listaCarrito = new BindingList<DetalleCarrito>();

        decimal fondoCaja = 0m;
        decimal totalVendidoDia = 0m;
        int idClienteSeleccionado = 1;
        int idVehiculoSeleccionado = 1;

        public frmFacturacion(decimal montoApertura)
        {
            InitializeComponent();
            fondoCaja = montoApertura;

            dgvCarrito.AutoGenerateColumns = false;
            dgvCarrito.Columns.Clear();

            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdProducto", HeaderText = "ID", Width = 50 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Producto", Width = 200 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant", Width = 50 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ITBIS", HeaderText = "ITBIS (18%)", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = "Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Acción";
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvCarrito.Columns.Add(btnEliminar);

            dgvCarrito.DataSource = listaCarrito;

            lblSucursal.Text = "Sucursal ID: " + SesionGlobal.IdSucursal.ToString();
            lblCajero.Text = "Cajero: " + SesionGlobal.NombreUsuario;
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

            if (numCantidad.Value > stockActual)
            {
                MessageBox.Show("No hay suficiente stock. Solo quedan " + stockActual + " unidades.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            stockActual = 0;
            lblStock.Text = "Stock Disponible: 0";
            txtIdProducto.Focus();
        }

        private void ActualizarTotal()
        {
            decimal subtotal = 0, itbis = 0, total = 0;

            foreach (var item in listaCarrito)
            {
                subtotal += item.Subtotal;
                itbis += item.ITBIS;
                total += item.Total;
            }

            lblSubtotalGeneral.Text = "Subtotal: $" + subtotal.ToString("N2");
            lblITBISGeneral.Text = "ITBIS: $" + itbis.ToString("N2");
            lblTotal.Text = "RD$ " + total.ToString("N2");
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
                    var producto = dbLocal.tblProductoCaches.FirstOrDefault(p => p.IdProducto == idBuscado);

                    if (producto != null)
                    {
                        txtNombreProducto.Text = producto.Nombre;
                        precioActual = producto.Precio ?? 0m;
                        stockActual = Convert.ToInt32(producto.Stock);
                        lblStock.Text = $"Stock Disponible: {stockActual}";
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
            catch (Exception)
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
                string nombreParaRecibo = "Cliente de Contado";

                if (!string.IsNullOrWhiteSpace(txtCedulaCliente.Text))
                {
                    var servicioBusqueda = new IntegracionReferencia.IntegracionServiceSoapClient();
                    var clienteBD = servicioBusqueda.BuscarClientePorCedulaRNC(txtCedulaCliente.Text);

                    if (clienteBD != null)
                    {
                        idClienteSeleccionado = clienteBD.IdCliente;
                        nombreParaRecibo = clienteBD.Nombre;
                    }
                    else
                    {
                        MessageBox.Show("La cédula no está registrada. Se facturará como Cliente de Contado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idClienteSeleccionado = 1;
                    }
                }
                else
                {
                    idClienteSeleccionado = 1;
                }

                int idCliente = idClienteSeleccionado;
                int idVehiculo = cmbVehiculos.SelectedValue != null ? (int)cmbVehiculos.SelectedValue : 1;
                int idUsuario = SesionGlobal.IdUsuario;
                int idSucursal = SesionGlobal.IdSucursal;
                string canalVenta = "CAJA";

                decimal totalPagar = listaCarrito.Sum(item => item.Total);

                frmCobro pantallaCobro = new frmCobro(totalPagar);
                if (pantallaCobro.ShowDialog() != DialogResult.OK)
                {

                    return;
                }

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
                visor.NombreCliente = nombreParaRecibo;
                visor.CedulaCliente = string.IsNullOrWhiteSpace(txtCedulaCliente.Text) ? "N/A" : txtCedulaCliente.Text;
                visor.MostrarRecibo(listaCarrito.ToList());
                visor.ShowDialog();

                foreach (var item in listaCarrito)
                {
                    VentasDelTurno.Add(new DetalleCarrito
                    {
                        IdProducto = item.IdProducto,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        Cantidad = item.Cantidad
                    });
                }

                listaCarrito.Clear();
                ActualizarTotal();
                txtCedulaCliente.Clear();
                idClienteSeleccionado = 1;
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
            if (string.IsNullOrWhiteSpace(txtCedulaCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula o RNC.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedulaCliente.Focus();
                return;
            }

            try
            {
                var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();
                var cliente = servicioIntegracion.BuscarClientePorCedulaRNC(txtCedulaCliente.Text);

                if (cliente != null)
                {
                    idClienteSeleccionado = cliente.IdCliente;

                    // 1. Mostrar el nombre fijamente en pantalla
                    lblNombreCliente.Text = "Cliente: " + cliente.Nombre;
                    lblNombreCliente.ForeColor = Color.Blue;

                    // 2. Buscar y llenar sus vehículos
                    var vehiculos = servicioIntegracion.ListarVehiculosCliente(cliente.IdCliente);

                    if (vehiculos != null && vehiculos.Length > 0)
                    {
                        // TRUCO MÁGICO: Armamos el texto "Display" aquí mismo en la caja
                        var listaVisual = vehiculos.Select(v => new
                        {
                            IdVehiculo = v.IdVehiculo,
                            Display = v.Marca + " " + v.Modelo + " - Placa: " + v.Placa
                        }).ToList();

                        cmbVehiculos.DataSource = listaVisual;
                        cmbVehiculos.DisplayMember = "Display";    // Ahora sí existe y lo va a encontrar
                        cmbVehiculos.ValueMember = "IdVehiculo";
                    }
                    else
                    {
                        cmbVehiculos.DataSource = null;
                        cmbVehiculos.Items.Clear();
                        cmbVehiculos.Items.Add("Sin vehículo registrado");
                        cmbVehiculos.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestablecerClienteContado();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar cliente. Trabajando en modo Offline.", "Modo Offline", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RestablecerClienteContado();
            }
        }

        private void RestablecerClienteContado()
        {
            idClienteSeleccionado = 1;
            lblNombreCliente.Text = "Cliente: Contado";
            lblNombreCliente.ForeColor = Color.Black;
            cmbVehiculos.DataSource = null;
            cmbVehiculos.Items.Clear();
            cmbVehiculos.Items.Add("N/A");
            cmbVehiculos.SelectedIndex = 0;
        }

        private void label6_Click(object sender, EventArgs e) { }

        private void label9_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCarrito.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar este producto del carrito?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    listaCarrito.RemoveAt(e.RowIndex);
                    ActualizarTotal();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmNuevoCliente pantallaNuevo = new frmNuevoCliente();
            pantallaNuevo.ShowDialog();
        }
    }

    public class DetalleCarrito
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => Precio * Cantidad;
        public decimal ITBIS => Subtotal * 0.18m;
        public decimal Total => Subtotal + ITBIS;
        public decimal Importe => Total;
    }
}