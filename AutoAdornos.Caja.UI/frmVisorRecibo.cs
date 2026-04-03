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

            this.reportViewer1.RefreshReport();
        }
    }
}
