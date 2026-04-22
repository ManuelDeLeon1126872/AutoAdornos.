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
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El usuario, clave y nombre completo son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sucursal válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                MessageBox.Show("Usuario guardado correctamente. Id: " + id, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarSucursales()
        {
            try
            {
                SucursalBL bl = new SucursalBL();
                cmbSucursal.DataSource = bl.ListarSucursalesAdmin();
                cmbSucursal.DisplayMember = "Nombre";
                cmbSucursal.ValueMember = "IdSucursal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                UsuarioBL bl = new UsuarioBL();
                dgvUsuarios.DataSource = bl.ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombreUsuario.Text = "";
            txtClave.Text = "";
            txtNombreCompleto.Text = "";
            chkEstado.Checked = true;
            if (cmbSucursal.Items.Count > 0)
                cmbSucursal.SelectedIndex = 0;
            txtNombreUsuario.Focus();
        }
    }
}