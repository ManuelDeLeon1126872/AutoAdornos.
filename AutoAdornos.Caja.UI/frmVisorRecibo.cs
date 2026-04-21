using Microsoft.Reporting.WinForms;
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
    public partial class frmVisorRecibo : Form
    {
        public string NombreCliente { get; set; } = "Cliente de Contado";
        public string CedulaCliente { get; set; } = "N/A";

        public frmVisorRecibo()
        {
            InitializeComponent();
        }

        public void MostrarRecibo(List<DetalleCarrito> listaComprada)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource fuenteDatos = new ReportDataSource("DataSetFactura", listaComprada);

            reportViewer1.LocalReport.DataSources.Add(fuenteDatos);
            reportViewer1.RefreshReport();
        }

        private void frmVisorRecibo_Load(object sender, EventArgs e)
        {
            string ced = string.IsNullOrWhiteSpace(CedulaCliente) ? "N/A" : CedulaCliente;
            string nombre = string.IsNullOrWhiteSpace(NombreCliente) ? "Cliente de Contado" : NombreCliente;

            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("pClienteCedula", ced);
            parametros[1] = new ReportParameter("pClienteNombre", nombre);

            this.reportViewer1.LocalReport.SetParameters(parametros);
            this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}