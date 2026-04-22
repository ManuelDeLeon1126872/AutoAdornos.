using System;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmSucursales : Form
    {
        public frmSucursales()
        {
            InitializeComponent();
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarSucursales();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SucursalBL bl = new SucursalBL();

                int id = bl.InsertarSucursal(
                    txtNombre.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    chkEstado.Checked
                );

                MessageBox.Show("Sucursal guardada correctamente. Id: " + id);
                Limpiar();
                CargarSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sucursal: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CargarSucursales()
        {
            SucursalBL bl = new SucursalBL();
            dgvSucursales.DataSource = bl.ListarSucursalesAdmin();
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            chkEstado.Checked = true;
        }
    }
}