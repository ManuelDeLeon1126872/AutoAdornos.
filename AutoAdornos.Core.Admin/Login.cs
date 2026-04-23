using AutoAdornos.Core.Business.Seguridad;
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

                    // Convertimos el perfil de forma segura. Si por alguna razón viene nulo, asume 1 (Admin)
                    int perfilDeteccion = usuarioAutenticado.IdPerfil != null ? Convert.ToInt32(usuarioAutenticado.IdPerfil) : 1;

                    // Le pasamos el perfil detectado al menú
                    frmMenuCore menuAdmin = new frmMenuCore(perfilDeteccion);
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