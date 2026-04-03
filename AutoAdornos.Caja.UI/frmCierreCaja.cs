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
    public partial class frmCierreCaja : Form
    {
        decimal fondoInicial;
        decimal totalVendido;

        public frmCierreCaja(decimal fondo, decimal ventas)
        {
            InitializeComponent();

            fondoInicial = fondo;
            totalVendido = ventas;

            txtFondoInicial.Text = fondoInicial.ToString("0.00");
            txtTotalVendido.Text = totalVendido.ToString("0.00");

            decimal esperado = fondoInicial + totalVendido;
            txtEsperado.Text = esperado.ToString("0.00");
        }

        private void btnCuadrar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDineroContado.Text, out decimal dineroContado))
            {
                MessageBox.Show("Ingrese un monto válido en el dinero contado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal esperado = fondoInicial + totalVendido;
            decimal diferencia = dineroContado - esperado;

            if (diferencia == 0)
            {
                MessageBox.Show("El dinero en caja es exacto.", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (diferencia > 0)
            {
                MessageBox.Show($"Cierre con SOBRANTE. Hay un sobrante de ${diferencia:0.00} en la caja.", "Cierre con Novedad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Cierre con FALTANTE. Faltan ${Math.Abs(diferencia):0.00} en la caja.", "Cierre con Novedad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            MessageBox.Show("Turno cerrado. El sistema se apagará.", "Fin del día", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
