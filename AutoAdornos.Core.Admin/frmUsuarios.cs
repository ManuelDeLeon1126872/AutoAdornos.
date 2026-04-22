using System;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Seguridad;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarSucursales();
            CargarUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBL bl = new UsuarioBL();

                int id = bl.InsertarUsuario(
                    txtNombreUsuario.Text.Trim(),
                    txtClave.Text.Trim(),
                    txtNombreCompleto.Text.Trim(),
                    Convert.ToInt32(cmbSucursal.SelectedValue),
                    chkEstado.Checked
                );

                MessageBox.Show("Usuario guardado correctamente. Id: " + id);
                Limpiar();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CargarSucursales()
        {
            SucursalBL bl = new SucursalBL();
            cmbSucursal.DataSource = bl.ListarSucursalesAdmin();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
        }

        private void CargarUsuarios()
        {
            UsuarioBL bl = new UsuarioBL();
            dgvUsuarios.DataSource = bl.ListarUsuarios();
        }

        private void Limpiar()
        {
            txtNombreUsuario.Text = "";
            txtClave.Text = "";
            txtNombreCompleto.Text = "";
            chkEstado.Checked = true;
            if (cmbSucursal.Items.Count > 0)
                cmbSucursal.SelectedIndex = 0;
        }
    }
}