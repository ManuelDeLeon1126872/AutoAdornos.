namespace AutoAdornos.Caja.UI
{
    partial class frmAperturaCaja
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
            this.panelModal = new System.Windows.Forms.Panel();
            this.btnRapido2000 = new System.Windows.Forms.Button();
            this.btnRapido1000 = new System.Windows.Forms.Button();
            this.btnRapido500 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.panelModal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelModal
            // 
            this.panelModal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelModal.BackColor = System.Drawing.Color.White;
            this.panelModal.Controls.Add(this.btnRapido2000);
            this.panelModal.Controls.Add(this.btnRapido1000);
            this.panelModal.Controls.Add(this.btnRapido500);
            this.panelModal.Controls.Add(this.btnCancelar);
            this.panelModal.Controls.Add(this.txtMontoInicial);
            this.panelModal.Controls.Add(this.label1);
            this.panelModal.Controls.Add(this.label2);
            this.panelModal.Controls.Add(this.btnAbrirCaja);
            this.panelModal.Location = new System.Drawing.Point(345, 160);
            this.panelModal.Name = "panelModal";
            this.panelModal.Size = new System.Drawing.Size(510, 480);
            this.panelModal.TabIndex = 0;
            // 
            // btnRapido2000
            // 
            this.btnRapido2000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnRapido2000.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRapido2000.FlatAppearance.BorderSize = 0;
            this.btnRapido2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapido2000.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRapido2000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btnRapido2000.Location = new System.Drawing.Point(337, 270);
            this.btnRapido2000.Name = "btnRapido2000";
            this.btnRapido2000.Size = new System.Drawing.Size(124, 40);
            this.btnRapido2000.TabIndex = 7;
            this.btnRapido2000.Text = "RD$ 2,000";
            this.btnRapido2000.UseVisualStyleBackColor = false;
            this.btnRapido2000.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btnRapido1000
            // 
            this.btnRapido1000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnRapido1000.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRapido1000.FlatAppearance.BorderSize = 0;
            this.btnRapido1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapido1000.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRapido1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btnRapido1000.Location = new System.Drawing.Point(192, 270);
            this.btnRapido1000.Name = "btnRapido1000";
            this.btnRapido1000.Size = new System.Drawing.Size(120, 40);
            this.btnRapido1000.TabIndex = 6;
            this.btnRapido1000.Text = "RD$ 1,000";
            this.btnRapido1000.UseVisualStyleBackColor = false;
            this.btnRapido1000.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btnRapido500
            // 
            this.btnRapido500.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnRapido500.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRapido500.FlatAppearance.BorderSize = 0;
            this.btnRapido500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapido500.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRapido500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btnRapido500.Location = new System.Drawing.Point(47, 270);
            this.btnRapido500.Name = "btnRapido500";
            this.btnRapido500.Size = new System.Drawing.Size(119, 40);
            this.btnRapido500.TabIndex = 5;
            this.btnRapido500.Text = "RD$ 500";
            this.btnRapido500.UseVisualStyleBackColor = false;
            this.btnRapido500.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(55, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(400, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.txtMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoInicial.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.txtMontoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.txtMontoInicial.Location = new System.Drawing.Point(55, 170);
            this.txtMontoInicial.Multiline = true;
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(400, 80);
            this.txtMontoInicial.TabIndex = 2;
            this.txtMontoInicial.Text = "0.00";
            this.txtMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(55, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor entre la cantidad de efectivo que hay en la caja para comenzar su jorna" +
    "da";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 90);
            this.label2.TabIndex = 0;
            this.label2.Text = "Abrir Caja";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirCaja.FlatAppearance.BorderSize = 0;
            this.btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.Location = new System.Drawing.Point(55, 340);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(400, 60);
            this.btnAbrirCaja.TabIndex = 3;
            this.btnAbrirCaja.Text = "ABRIR CAJA REGISTRADORA";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelModal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura de Caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelModal.ResumeLayout(false);
            this.panelModal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelModal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRapido2000;
        private System.Windows.Forms.Button btnRapido1000;
        private System.Windows.Forms.Button btnRapido500;
    }
}