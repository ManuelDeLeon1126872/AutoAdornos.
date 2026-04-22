using AutoAdornos.Core.Business.Seguridad; // Importante para poder usar UsuarioBL
using System;
using System.Windows.Forms;

namespace AutoAdornos.Core.Admin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Como estamos en el Core Admin, validamos directo con la base de datos (Business Layer)
                UsuarioBL bl = new UsuarioBL();

                // Si el usuario existe y está activo, esto nos devuelve sus datos
                var usuarioAutenticado = bl.ValidarUsuario(txtUsuario.Text, txtClave.Text);

                if (usuarioAutenticado != null)
                {
                    this.Hide();

                    // Llevamos al usuario al menú de administración
                    frmMenuCore menuAdmin = new frmMenuCore();
                    menuAdmin.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}