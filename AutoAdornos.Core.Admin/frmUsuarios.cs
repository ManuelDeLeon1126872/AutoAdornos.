using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Seguridad;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmUsuarios : Form
    {
        private int idUsuarioEditando = 0;

        public frmUsuarios()
        {
            InitializeComponent();
            // Conectamos el evento de doble clic
            this.dgvUsuarios.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarSucursales();
            CargarPerfiles(); // Cargamos el combo de Admin/Cajero
            CargarUsuarios();
        }

        private void CargarPerfiles()
        {
            // Creamos las opciones de perfil manualmente
            Dictionary<int, string> perfiles = new Dictionary<int, string>();
            perfiles.Add(1, "Administrador");
            perfiles.Add(2, "Cajero");

            cmbPerfil.DataSource = new BindingSource(perfiles, null);
            cmbPerfil.DisplayMember = "Value";
            cmbPerfil.ValueMember = "Key";
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                idUsuarioEditando = Convert.ToInt32(fila.Cells["IdUsuario"].Value);

                txtNombreUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value.ToString();
                // La clave generalmente no se muestra por seguridad, se deja en blanco para que ponga una nueva si quiere
                txtClave.Text = "";

                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                if (fila.Cells["IdSucursal"].Value != DBNull.Value)
                    cmbSucursal.SelectedValue = Convert.ToInt32(fila.Cells["IdSucursal"].Value);

                if (fila.Cells["IdPerfil"].Value != DBNull.Value)
                    cmbPerfil.SelectedValue = Convert.ToInt32(fila.Cells["IdPerfil"].Value);

                btnGuardar.Text = "ACTUALIZAR USUARIO";
                btnGuardar.BackColor = Color.FromArgb(11, 110, 42);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El usuario y nombre completo son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioBL bl = new UsuarioBL();
                int idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
                int idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);

                if (idUsuarioEditando == 0)
                {
                    // NUEVO (Necesita requerir clave)
                    if (string.IsNullOrWhiteSpace(txtClave.Text)) { MessageBox.Show("Ingrese una clave para el nuevo usuario."); return; }

                    bl.InsertarUsuario(txtNombreUsuario.Text.Trim(), txtClave.Text.Trim(), txtNombreCompleto.Text.Trim(), idSucursal, chkEstado.Checked, idPerfil);
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ACTUALIZAR (Si la clave está vacía, el backend no debería cambiarla)
                    bl.ActualizarUsuario(idUsuarioEditando, txtNombreUsuario.Text.Trim(), txtClave.Text.Trim(), txtNombreCompleto.Text.Trim(), idSucursal, chkEstado.Checked, idPerfil);
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Limpiar();
                CargarUsuarios();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioEditando == 0)
            {
                MessageBox.Show("Por favor, haga doble clic en un usuario de la lista para seleccionarlo y luego presione Eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este usuario de forma permanente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    new UsuarioBL().EliminarUsuario(idUsuarioEditando);
                    MessageBox.Show("Usuario eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    CargarUsuarios();
                }
                catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnListar_Click(object sender, EventArgs e) { CargarUsuarios(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { Limpiar(); }
        private void btnCerrar_Click(object sender, EventArgs e) { this.Close(); }

        private void CargarSucursales()
        {
            try
            {
                cmbSucursal.DataSource = new SucursalBL().ListarSucursalesAdmin();
                cmbSucursal.DisplayMember = "Nombre";
                cmbSucursal.ValueMember = "IdSucursal";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void CargarUsuarios()
        {
            try { dgvUsuarios.DataSource = new UsuarioBL().ListarUsuarios(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Limpiar()
        {
            idUsuarioEditando = 0;
            txtNombreUsuario.Text = "";
            txtClave.Text = "";
            txtNombreCompleto.Text = "";
            chkEstado.Checked = true;
            if (cmbSucursal.Items.Count > 0) cmbSucursal.SelectedIndex = 0;
            if (cmbPerfil.Items.Count > 0) cmbPerfil.SelectedIndex = 0;

            btnGuardar.Text = "GUARDAR USUARIO";
            btnGuardar.BackColor = Color.FromArgb(10, 17, 40);
            txtNombreUsuario.Focus();
        }
    }
}