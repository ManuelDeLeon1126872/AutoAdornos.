using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace AutoAdornos.Caja.UI
{
    public partial class frmCierreCaja : Form
    {
        decimal fondoInicial;
        decimal totalVendido;
        decimal dineroContadoFinal = 0;
        decimal diferenciaFinal = 0;
        string estadoCierre = "";

        private PrintDocument docCierre = new PrintDocument();
        private PrintPreviewDialog previewCierre = new PrintPreviewDialog();

        public frmCierreCaja(decimal fondo, decimal ventas)
        {
            InitializeComponent();

            fondoInicial = fondo;
            totalVendido = ventas;

            txtFondoInicial.Text = fondoInicial.ToString("0.00");
            txtTotalVendido.Text = totalVendido.ToString("0.00");

            decimal esperado = fondoInicial + totalVendido;
            txtEsperado.Text = esperado.ToString("0.00");

            docCierre.PrintPage += new PrintPageEventHandler(DibujarReporteZ);

            ConfigurarTablaVentas();
        }

        private void ConfigurarTablaVentas()
        {
            // Configurar columnas manualmente para un diseño limpio
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.Columns.Clear();

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant", Width = 50 });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Producto", Width = 200 });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = "Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            // Llenar la tabla con el historial que guardamos en Facturación
            dgvVentas.DataSource = frmFacturacion.VentasDelTurno;
        }

        private void btnCuadrar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDineroContado.Text, out dineroContadoFinal))
            {
                MessageBox.Show("Ingrese un monto válido en el dinero contado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal esperado = fondoInicial + totalVendido;
            diferenciaFinal = dineroContadoFinal - esperado;

            if (diferenciaFinal == 0)
            {
                estadoCierre = "CUADRE EXACTO";
                lblResultado.Text = "¡Cuadre Exacto! Todo en orden.";
                lblResultado.ForeColor = Color.Green;
            }
            else if (diferenciaFinal > 0)
            {
                estadoCierre = "SOBRANTE";
                lblResultado.Text = $"Sobrante en caja de: RD$ {diferenciaFinal:0.00}";
                lblResultado.ForeColor = Color.Blue;
            }
            else
            {
                estadoCierre = "FALTANTE";
                lblResultado.Text = $"Faltante en caja de: RD$ {Math.Abs(diferenciaFinal):0.00}";
                lblResultado.ForeColor = Color.Red;
            }

            btnCuadrar.Visible = false;
            btnImprimir.Visible = true;
            txtDineroContado.ReadOnly = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            previewCierre.Document = docCierre;
            previewCierre.WindowState = FormWindowState.Maximized;
            previewCierre.ShowDialog();

            MessageBox.Show("Turno cerrado correctamente. El sistema se apagará.", "Fin del día", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void DibujarReporteZ(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            Font fontSubtitulo = new Font("Segoe UI", 12, FontStyle.Bold);
            Font fontNormal = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fontFina = new Font("Consolas", 10, FontStyle.Regular);

            int y = 50;
            int x = 50;

            g.DrawString("AUTO ADORNOS - REPORTE (CIERRE DE CAJA)", fontTitulo, Brushes.Black, x, y);
            y += 30;
            g.DrawString($"Fecha y Hora: {DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")}", fontNormal, Brushes.Black, x, y);
            y += 20;
            g.DrawString($"Cajero: {SesionGlobal.NombreUsuario} (ID: {SesionGlobal.IdUsuario})", fontNormal, Brushes.Black, x, y);
            y += 20;
            g.DrawString($"Sucursal ID: {SesionGlobal.IdSucursal}", fontNormal, Brushes.Black, x, y);
            y += 40;

            g.DrawString("--------------------------------------------------------------------------------", fontNormal, Brushes.Black, x, y);
            y += 20;
            g.DrawString("DETALLE DE PRODUCTOS VENDIDOS HOY", fontSubtitulo, Brushes.Black, x, y);
            y += 30;
            g.DrawString("CANT   DESCRIPCIÓN                                        TOTAL", fontSubtitulo, Brushes.Black, x, y);
            y += 25;

            if (frmFacturacion.VentasDelTurno.Count == 0)
            {
                g.DrawString("No se registraron ventas en este turno.", fontNormal, Brushes.Gray, x, y);
                y += 25;
            }
            else
            {
                foreach (var venta in frmFacturacion.VentasDelTurno)
                {
                    string linea = $"{venta.Cantidad}x    {venta.Descripcion}";
                    if (linea.Length > 45) linea = linea.Substring(0, 45);
                    linea = linea.PadRight(50);
                    linea += $"RD$ {venta.Total:0.00}";

                    g.DrawString(linea, fontFina, Brushes.Black, x, y);
                    y += 20;
                }
            }

            y += 10;
            g.DrawString("--------------------------------------------------------------------------------", fontNormal, Brushes.Black, x, y);
            y += 30;
            g.DrawString("RESUMEN FINANCIERO", fontSubtitulo, Brushes.Black, x, y);
            y += 30;

            g.DrawString($"Fondo Inicial (Apertura):        RD$ {fondoInicial:0.00}", fontNormal, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Total Ingresos por Ventas:       RD$ {totalVendido:0.00}", fontNormal, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"EFECTIVO ESPERADO EN CAJA:       RD$ {(fondoInicial + totalVendido):0.00}", fontSubtitulo, Brushes.Black, x, y);
            y += 30;

            g.DrawString($"Efectivo Contado Físicamente:    RD$ {dineroContadoFinal:0.00}", fontNormal, Brushes.Black, x, y);
            y += 25;

            Brush colorDiferencia = diferenciaFinal == 0 ? Brushes.Green : (diferenciaFinal > 0 ? Brushes.Blue : Brushes.Red);
            g.DrawString($"DIFERENCIA ({estadoCierre}):      RD$ {diferenciaFinal:0.00}", fontSubtitulo, colorDiferencia, x, y);

            y += 80;
            g.DrawString("__________________________________________", fontNormal, Brushes.Black, x, y);
            y += 20;
            g.DrawString("FIRMA DEL CAJERO", fontNormal, Brushes.Black, x + 60, y);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
        }
    }
}