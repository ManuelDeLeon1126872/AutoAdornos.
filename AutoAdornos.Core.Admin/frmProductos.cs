using System;
using System.Drawing;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmProductos : Form
    {
        private int idProductoEditando = 0;
        private int _perfilUsuario; // Aquí guardamos si es Cajero o Admin

        // Modificamos el constructor para recibir quién abrió la pantalla
        public frmProductos(int perfilUsuario = 1)
        {
            InitializeComponent();
            _perfilUsuario = perfilUsuario;
            this.dgvProductos.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarProductos();

            // MODO CAJERO (Solo Lectura)
            if (_perfilUsuario == 2)
            {
                // Deshabilitamos que puedan escribir
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPrecio.Enabled = false;
                txtExistencia.Enabled = false;
                chkEstado.Enabled = false;

                // Escondemos los botones peligrosos
                btnGuardar.Visible = false;
                btnLimpiar.Visible = false;

                this.Text = "Inventario de Productos - MODO LECTURA";
                MessageBox.Show("Modo Cajero: Puede consultar el inventario, pero no modificarlo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si es Cajero, no hacemos nada al hacer doble clic
            if (_perfilUsuario == 2) return;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
                idProductoEditando = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtExistencia.Text = fila.Cells["Existencia"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                btnGuardar.Text = "ACTUALIZAR PRODUCTO";
                btnGuardar.BackColor = Color.FromArgb(11, 110, 42);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El código y la descripción son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ProductoBL bl = new ProductoBL();

                if (idProductoEditando == 0)
                {
                    bl.InsertarProducto(txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), decimal.Parse(txtPrecio.Text), int.Parse(txtExistencia.Text), chkEstado.Checked);
                    MessageBox.Show("Producto creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bl.ActualizarProducto(idProductoEditando, txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), decimal.Parse(txtPrecio.Text), int.Parse(txtExistencia.Text), chkEstado.Checked);
                    MessageBox.Show("Inventario/Producto actualizado correctamente.", "Restock Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Limpiar();
                CargarProductos();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnListar_Click(object sender, EventArgs e) { CargarProductos(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { Limpiar(); }
        private void btnCerrar_Click(object sender, EventArgs e) { this.Close(); }

        private void CargarProductos()
        {
            try { dgvProductos.DataSource = new ProductoBL().ListarProductosAdmin(); }
            catch (Exception ex) { MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Limpiar()
        {
            idProductoEditando = 0;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            chkEstado.Checked = true;

            btnGuardar.Text = "GUARDAR PRODUCTO";
            btnGuardar.BackColor = Color.FromArgb(10, 17, 40);
            txtCodigo.Focus();
        }
    }
}