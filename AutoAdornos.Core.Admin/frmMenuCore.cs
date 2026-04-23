using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoAdornos.Core.Admin
{
    public partial class frmMenuCore : Form
    {
        // Variable para guardar quién entró
        private int _idPerfilUsuario;

        // Modificamos el constructor para recibir el perfil
        public frmMenuCore(int idPerfil = 1)
        {
            InitializeComponent();
            _idPerfilUsuario = idPerfil;

            // ESTA ES LA LÍNEA MÁGICA: Obliga a Windows Forms a ejecutar el evento Load al abrir la pantalla
            this.Load += new EventHandler(frmMenuCore_Load);
        }

        private void frmMenuCore_Load(object sender, EventArgs e)
        {
            // Si es un Cajero (2), deshabilitamos la administración
            if (_idPerfilUsuario == 2)
            {
                // Cambiamos el texto y color del indicador de acceso
                lblAcceso.Text = "ACCESO: CAJERO";
                lblAcceso.ForeColor = Color.LightSkyBlue;

                // Deshabilitamos el botón de usuarios y lo ponemos gris
                btnUsuarios.Enabled = false;
                btnUsuarios.BackColor = Color.FromArgb(235, 235, 235);
                btnUsuarios.ForeColor = Color.DarkGray;
                btnUsuarios.FlatAppearance.BorderColor = Color.LightGray;

                // Deshabilitamos el botón de sucursales y lo ponemos gris
                btnSucursales.Enabled = false;
                btnSucursales.BackColor = Color.FromArgb(235, 235, 235);
                btnSucursales.ForeColor = Color.DarkGray;
                btnSucursales.FlatAppearance.BorderColor = Color.LightGray;

                this.Text = "TurboPOS ADMIN - Modo Cajero (Solo Lectura)";
            }
            else
            {
                // Si es Administrador (1), lo ve todo con sus colores normales
                lblAcceso.Text = "ACCESO: ADMINISTRADOR";
                lblAcceso.ForeColor = Color.Gold;
                this.Text = "TurboPOS ADMIN - Modo Administrador";
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new frmUsuarios().ShowDialog();
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            new frmSucursales().ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Importante: Le pasamos el perfil actual a la pantalla de productos
            new frmProductos(_idPerfilUsuario).ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}