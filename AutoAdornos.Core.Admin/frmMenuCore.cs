using System;
using System.Windows.Forms;

namespace AutoAdornos.Core.Admin
{
    public partial class frmMenuCore : Form
    {
        public frmMenuCore()
        {
            InitializeComponent();
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
            new frmProductos().ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}