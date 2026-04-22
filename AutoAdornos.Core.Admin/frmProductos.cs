using System;
using System.Drawing;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmProductos : Form
    {
        // 1. Variable mágica para saber si estamos creando o editando
        private int idProductoEditando = 0;

        public frmProductos()
        {
            InitializeComponent();

            // 2. Conectamos el evento de Doble Clic a la tabla desde aquí
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarProductos();
        }

        // 3. El evento que se dispara al hacer doble clic en la tabla
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Extraemos la fila a la que se le hizo clic
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                // Llenamos el formulario con los datos de esa fila
                idProductoEditando = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtExistencia.Text = fila.Cells["Existencia"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                // Cambiamos el estilo del botón para indicar que estamos en MODO EDICIÓN
                btnGuardar.Text = "ACTUALIZAR PRODUCTO";
                btnGuardar.BackColor = Color.FromArgb(11, 110, 42); // Verde para actualizar
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

                // Revisamos si la variable está en 0 (NUEVO) o tiene un ID (EDITANDO)
                if (idProductoEditando == 0)
                {
                    // MODO CREACIÓN
                    int id = bl.InsertarProducto(
                        txtCodigo.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        decimal.Parse(txtPrecio.Text),
                        int.Parse(txtExistencia.Text),
                        chkEstado.Checked
                    );
                    MessageBox.Show("Producto creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODO ACTUALIZACIÓN (RESTOCK)
                    bl.ActualizarProducto(
                        idProductoEditando,
                        txtCodigo.Text.Trim(),
                        txtDescripcion.Text.Trim(),
                        decimal.Parse(txtPrecio.Text),
                        int.Parse(txtExistencia.Text),
                        chkEstado.Checked
                    );
                    MessageBox.Show("Inventario/Producto actualizado correctamente.", "Restock Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Limpiar();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: Verifique que su compañero haya creado el método ActualizarProducto en ProductoBL. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarProductos()
        {
            try
            {
                ProductoBL bl = new ProductoBL();
                dgvProductos.DataSource = bl.ListarProductosAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            idProductoEditando = 0; // Reseteamos la variable mágica
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            chkEstado.Checked = true;

            // Devolvemos el botón a su estilo original (Azul y Nuevo)
            btnGuardar.Text = "GUARDAR PRODUCTO";
            btnGuardar.BackColor = Color.FromArgb(10, 17, 40);

            txtCodigo.Focus();
        }
    }
}