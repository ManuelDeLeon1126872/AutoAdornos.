using System;
using System.Drawing;
using System.Windows.Forms;
using AutoAdornos.Core.Business.Catalogos;

namespace AutoAdornos.Core.Admin
{
    public partial class frmSucursales : Form
    {
        private int idSucursalEditando = 0;

        public frmSucursales()
        {
            InitializeComponent();
            this.dgvSucursales.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSucursales_CellDoubleClick);
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            chkEstado.Checked = true;
            CargarSucursales();
        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvSucursales.Rows[e.RowIndex];
                idSucursalEditando = Convert.ToInt32(fila.Cells["IdSucursal"].Value);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"] != null ? fila.Cells["Telefono"].Value.ToString() : "";
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                btnGuardar.Text = "ACTUALIZAR SUCURSAL";
                btnGuardar.BackColor = Color.FromArgb(11, 110, 42);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("El nombre y la dirección son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SucursalBL bl = new SucursalBL();

                if (idSucursalEditando == 0)
                {
                    bl.InsertarSucursal(txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), chkEstado.Checked);
                    MessageBox.Show("Sucursal guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bl.ActualizarSucursal(idSucursalEditando, txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), chkEstado.Checked);
                    MessageBox.Show("Sucursal actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Limpiar();
                CargarSucursales();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSucursalEditando == 0)
            {
                MessageBox.Show("Haga doble clic en una sucursal para seleccionarla y luego presione Eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Desea eliminar esta sucursal?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    new SucursalBL().EliminarSucursal(idSucursalEditando);
                    MessageBox.Show("Sucursal eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    CargarSucursales();
                }
                catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnListar_Click(object sender, EventArgs e) { CargarSucursales(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { Limpiar(); }
        private void btnCerrar_Click(object sender, EventArgs e) { this.Close(); }

        private void CargarSucursales()
        {
            try { dgvSucursales.DataSource = new SucursalBL().ListarSucursalesAdmin(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Limpiar()
        {
            idSucursalEditando = 0;
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            chkEstado.Checked = true;

            btnGuardar.Text = "GUARDAR SUCURSAL";
            btnGuardar.BackColor = Color.FromArgb(10, 17, 40);
            txtNombre.Focus();
        }
    }
}