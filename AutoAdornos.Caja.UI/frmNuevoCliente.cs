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
                return;
            }

            try
            {
                var servicio = new IntegracionReferencia.IntegracionServiceSoapClient();

                string respuestaCliente = servicio.InsertarCliente(
                    txtNombre.Text,
                    txtCedula.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    txtEmail.Text
                );

                if (respuestaCliente == "OK")
                {
                    var clienteBD = servicio.BuscarClientePorCedulaRNC(txtCedula.Text);

                    if (clienteBD != null && !string.IsNullOrWhiteSpace(txtMarca.Text))
                    {
                        servicio.InsertarVehiculo(
                            clienteBD.IdCliente,
                            txtMarca.Text,
                            txtModelo.Text,
                            txtAnio.Text,
                            txtPlaca.Text,
                            "N/A"
                        );
                    }

                    MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(respuestaCliente, "Error al crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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