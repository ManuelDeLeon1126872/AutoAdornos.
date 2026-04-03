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
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoInicial.Text, out decimal montoInicial) || montoInicial < 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show($"Caja abierta exitosamente con un fondo de ${montoInicial:0.00}.", "Apertura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();

            frmFacturacion pantallaCaja = new frmFacturacion(montoInicial);
            pantallaCaja.ShowDialog();

            this.Close();
        }
    }
}
