using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAdornos.Caja.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
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
                var servicioIntegracion = new IntegracionReferencia.IntegracionServiceSoapClient();

                bool accesoConcedido = servicioIntegracion.ValidarUsuario(txtUsuario.Text, txtClave.Text);

                if (accesoConcedido)
                {
                    this.Hide();

                    frmAperturaCaja pantallaApertura = new frmAperturaCaja();
                    pantallaApertura.ShowDialog();

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
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
