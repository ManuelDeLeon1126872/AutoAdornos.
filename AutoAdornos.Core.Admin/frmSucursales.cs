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
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("El nombre y la dirección son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SucursalBL bl = new SucursalBL();

                int id = bl.InsertarSucursal(
                    txtNombre.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    chkEstado.Checked
                );

                MessageBox.Show("Sucursal guardada correctamente. Id: " + id, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarSucursales()
        {
            try
            {
                SucursalBL bl = new SucursalBL();
                dgvSucursales.DataSource = bl.ListarSucursalesAdmin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            chkEstado.Checked = true;
            txtNombre.Focus();
        }
    }
}