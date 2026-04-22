using System;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoBL bl = new ProductoBL();

                int id = bl.InsertarProducto(
                    txtCodigo.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    decimal.Parse(txtPrecio.Text),
                    int.Parse(txtExistencia.Text),
                    chkEstado.Checked
                );

                MessageBox.Show("Producto guardado correctamente. Id: " + id);
                Limpiar();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto: " + ex.Message);
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

        private void CargarProductos()
        {
            ProductoBL bl = new ProductoBL();
            dgvProductos.DataSource = bl.ListarProductosAdmin();
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            chkEstado.Checked = true;
        }


    }
}