namespace AutoAdornos.Caja.UI
{
    partial class frmCierreCaja
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelModal = new System.Windows.Forms.Panel();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsperado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDineroContado = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCuadrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFondoInicial = new System.Windows.Forms.TextBox();
            this.txtTotalVendido = new System.Windows.Forms.TextBox();
            this.panelModal.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelModal
            // 
            this.panelModal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelModal.BackColor = System.Drawing.Color.White;
            this.panelModal.Controls.Add(this.panelIzquierdo);
            this.panelModal.Controls.Add(this.panelDerecho);
            this.panelModal.Controls.Add(this.panelHeader);
            this.panelModal.Location = new System.Drawing.Point(100, 50);
            this.panelModal.Name = "panelModal";
            this.panelModal.Size = new System.Drawing.Size(1000, 700);
            this.panelModal.TabIndex = 0;
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelIzquierdo.Controls.Add(this.label1);
            this.panelIzquierdo.Controls.Add(this.dgvVentas);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(0, 110);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(500, 590);
            this.panelIzquierdo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESUMEN DE VENTAS";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AllowUserToResizeColumns = false;
            this.dgvVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVentas.ColumnHeadersHeight = 35;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(230)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.Location = new System.Drawing.Point(20, 60);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 35;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(460, 500);
            this.dgvVentas.TabIndex = 0;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.White;
            this.panelDerecho.Controls.Add(this.label3);
            this.panelDerecho.Controls.Add(this.txtEsperado);
            this.panelDerecho.Controls.Add(this.label4);
            this.panelDerecho.Controls.Add(this.txtDineroContado);
            this.panelDerecho.Controls.Add(this.lblResultado);
            this.panelDerecho.Controls.Add(this.btnCuadrar);
            this.panelDerecho.Controls.Add(this.btnImprimir);
            this.panelDerecho.Controls.Add(this.btnCancelar);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDerecho.Location = new System.Drawing.Point(500, 110);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(500, 590);
            this.panelDerecho.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(40, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "CANTIDAD ESPERADA";
            // 
            // txtEsperado
            // 
            this.txtEsperado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.txtEsperado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEsperado.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtEsperado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.txtEsperado.Location = new System.Drawing.Point(44, 50);
            this.txtEsperado.Multiline = true;
            this.txtEsperado.Name = "txtEsperado";
            this.txtEsperado.ReadOnly = true;
            this.txtEsperado.Size = new System.Drawing.Size(420, 50);
            this.txtEsperado.TabIndex = 2;
            this.txtEsperado.Text = "0.00";
            this.txtEsperado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(40, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "EFECTIVO CONTADO";
            // 
            // txtDineroContado
            // 
            this.txtDineroContado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.txtDineroContado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDineroContado.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.txtDineroContado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.txtDineroContado.Location = new System.Drawing.Point(44, 150);
            this.txtDineroContado.Multiline = true;
            this.txtDineroContado.Name = "txtDineroContado";
            this.txtDineroContado.Size = new System.Drawing.Size(420, 60);
            this.txtDineroContado.TabIndex = 4;
            this.txtDineroContado.Text = "0.00";
            this.txtDineroContado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(44, 240);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(420, 40);
            this.lblResultado.TabIndex = 7;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCuadrar
            // 
            this.btnCuadrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnCuadrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCuadrar.FlatAppearance.BorderSize = 0;
            this.btnCuadrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuadrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCuadrar.ForeColor = System.Drawing.Color.White;
            this.btnCuadrar.Location = new System.Drawing.Point(44, 300);
            this.btnCuadrar.Name = "btnCuadrar";
            this.btnCuadrar.Size = new System.Drawing.Size(420, 60);
            this.btnCuadrar.TabIndex = 5;
            this.btnCuadrar.Text = "CALCULAR Y CONFIRMAR CIERRE";
            this.btnCuadrar.UseVisualStyleBackColor = false;
            this.btnCuadrar.Click += new System.EventHandler(this.btnCuadrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(44, 380);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(420, 60);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "IMPRIMIR REPORTE DE CIERRE";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btnCancelar.Location = new System.Drawing.Point(44, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(420, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar / Volver";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.panelHeader.Controls.Add(this.lblSub);
            this.panelHeader.Controls.Add(this.label5);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 110);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblSub.Location = new System.Drawing.Point(35, 70);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(351, 23);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Compara los totales con el efectivo del cajón";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(30, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 46);
            this.label5.TabIndex = 0;
            this.label5.Text = "FIN DE JORNADA";
            // 
            // txtFondoInicial
            // 
            this.txtFondoInicial.Location = new System.Drawing.Point(12, 12);
            this.txtFondoInicial.Name = "txtFondoInicial";
            this.txtFondoInicial.Size = new System.Drawing.Size(100, 22);
            this.txtFondoInicial.TabIndex = 1;
            this.txtFondoInicial.Visible = false;
            // 
            // txtTotalVendido
            // 
            this.txtTotalVendido.Location = new System.Drawing.Point(12, 40);
            this.txtTotalVendido.Name = "txtTotalVendido";
            this.txtTotalVendido.Size = new System.Drawing.Size(100, 22);
            this.txtTotalVendido.TabIndex = 2;
            this.txtTotalVendido.Visible = false;
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.txtTotalVendido);
            this.Controls.Add(this.txtFondoInicial);
            this.Controls.Add(this.panelModal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCierreCaja_Load);
            this.panelModal.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelDerecho.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelModal;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsperado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDineroContado;
        private System.Windows.Forms.Button btnCuadrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtFondoInicial;
        private System.Windows.Forms.TextBox txtTotalVendido;
    }
}