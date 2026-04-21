using System;
using System.Windows.Forms;

namespace AutoAdornos.Caja.UI
{
    public partial class frmNuevoCliente : Form
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El nombre y la cédula son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                var servicio = new IntegracionReferencia.IntegracionServiceSoapClient();

                string respuesta = servicio.InsertarCliente(
                    txtNombre.Text,
                    txtCedula.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    txtEmail.Text
                );

                if (respuesta == "OK")
                {
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(respuesta, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con el servidor: " + ex.Message, "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}