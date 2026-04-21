using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoAdornos.Caja.UI
{
    public partial class frmCobro : Form
    {
        public decimal TotalPagar { get; set; }
        public string MetodoPagoSeleccionado { get; set; }

        public frmCobro(decimal total)
        {
            InitializeComponent();
            TotalPagar = total;

            // Configuración visual básica para que parezca un popup modal inmersivo
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None; // Quitamos el borde feo de Windows
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Procesar Pago";
        }

        private void frmCobro_Load(object sender, EventArgs e)
        {
            lblTotalPagando.Text = "RD$ " + TotalPagar.ToString("N2");

            cmbMetodoPago.Items.Add("EFECTIVO");
            cmbMetodoPago.Items.Add("TARJETA DE CRÉDITO");
            cmbMetodoPago.Items.Add("TRANSFERENCIA BANCARIA");
            cmbMetodoPago.SelectedIndex = 0; // Efectivo por defecto

            txtMontoRecibido.Focus();
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem.ToString() != "EFECTIVO")
            {
                // Si es tarjeta o transferencia, asume el pago exacto
                txtMontoRecibido.Text = TotalPagar.ToString("0.00");
                txtMontoRecibido.Enabled = false;
                OcultarBotonesRapidos(true);
            }
            else
            {
                txtMontoRecibido.Enabled = true;
                txtMontoRecibido.Clear();
                OcultarBotonesRapidos(false);
                txtMontoRecibido.Focus();
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                decimal devuelta = montoRecibido - TotalPagar;

                if (devuelta >= 0)
                {
                    lblDevuelta.Text = "RD$ " + devuelta.ToString("N2");
                    lblDevuelta.ForeColor = Color.FromArgb(11, 110, 42); // Verde Corporativo
                    lblTextoDevuelta.Text = "DEVUELTA AL CLIENTE:";
                }
                else
                {
                    lblDevuelta.Text = "RD$ " + Math.Abs(devuelta).ToString("N2");
                    lblDevuelta.ForeColor = Color.FromArgb(225, 6, 0); // Rojo Racing
                    lblTextoDevuelta.Text = "FALTAN POR COBRAR:";
                }
            }
            else
            {
                lblDevuelta.Text = "RD$ 0.00";
                lblDevuelta.ForeColor = Color.FromArgb(10, 17, 40); // Azul Marino Default
                lblTextoDevuelta.Text = "CAMBIO:";
            }
        }

        // Nuevo método para los billetes rápidos
        private void btnRapido_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string montoTexto = btn.Text.Replace("RD$ ", "").Replace(",", "");

            // Si hay un "Exacto", pone el total a pagar
            if (btn.Text == "EXACTO")
            {
                txtMontoRecibido.Text = TotalPagar.ToString("0.00");
            }
            else
            {
                txtMontoRecibido.Text = montoTexto;
            }
        }

        private void OcultarBotonesRapidos(bool ocultar)
        {
            btnExacto.Visible = !ocultar;
            btn500.Visible = !ocultar;
            btn1000.Visible = !ocultar;
            btn2000.Visible = !ocultar;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido) || montoRecibido < TotalPagar)
            {
                MessageBox.Show("El monto recibido no es suficiente para cubrir el total.", "Pago Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoRecibido.Focus();
                return;
            }

            MetodoPagoSeleccionado = cmbMetodoPago.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK; // Le dice a la pantalla principal que todo fue un éxito
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}