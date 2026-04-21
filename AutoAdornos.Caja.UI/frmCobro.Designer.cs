namespace AutoAdornos.Caja.UI
{
    partial class frmCobro
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblDevuelta = new System.Windows.Forms.Label();
            this.lblTextoDevuelta = new System.Windows.Forms.Label();
            this.btn2000 = new System.Windows.Forms.Button();
            this.btn1000 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.btnExacto = new System.Windows.Forms.Button();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPagando = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.btnCancelar);
            this.panelMain.Controls.Add(this.btnCobrar);
            this.panelMain.Controls.Add(this.panelFooter);
            this.panelMain.Controls.Add(this.btn2000);
            this.panelMain.Controls.Add(this.btn1000);
            this.panelMain.Controls.Add(this.btn500);
            this.panelMain.Controls.Add(this.btnExacto);
            this.panelMain.Controls.Add(this.txtMontoRecibido);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.cmbMetodoPago);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.lblTotalPagando);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(650, 750);
            this.panelMain.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(44, 650);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 70);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(6)))), ((int)(((byte)(0)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Location = new System.Drawing.Point(230, 650);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(374, 70);
            this.btnCobrar.TabIndex = 12;
            this.btnCobrar.Text = "EFECTUAR COBRO";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.lblDevuelta);
            this.panelFooter.Controls.Add(this.lblTextoDevuelta);
            this.panelFooter.Location = new System.Drawing.Point(44, 530);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(560, 100);
            this.panelFooter.TabIndex = 11;
            // 
            // lblDevuelta
            // 
            this.lblDevuelta.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold);
            this.lblDevuelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.lblDevuelta.Location = new System.Drawing.Point(200, 20);
            this.lblDevuelta.Name = "lblDevuelta";
            this.lblDevuelta.Size = new System.Drawing.Size(340, 60);
            this.lblDevuelta.TabIndex = 1;
            this.lblDevuelta.Text = "RD$ 0.00";
            this.lblDevuelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTextoDevuelta
            // 
            this.lblTextoDevuelta.AutoSize = true;
            this.lblTextoDevuelta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTextoDevuelta.ForeColor = System.Drawing.Color.Gray;
            this.lblTextoDevuelta.Location = new System.Drawing.Point(20, 35);
            this.lblTextoDevuelta.Name = "lblTextoDevuelta";
            this.lblTextoDevuelta.Size = new System.Drawing.Size(96, 28);
            this.lblTextoDevuelta.TabIndex = 0;
            this.lblTextoDevuelta.Text = "CAMBIO:";
            // 
            // btn2000
            // 
            this.btn2000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.btn2000.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2000.FlatAppearance.BorderSize = 0;
            this.btn2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2000.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn2000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btn2000.Location = new System.Drawing.Point(474, 460);
            this.btn2000.Name = "btn2000";
            this.btn2000.Size = new System.Drawing.Size(130, 50);
            this.btn2000.TabIndex = 10;
            this.btn2000.Text = "RD$ 2,000";
            this.btn2000.UseVisualStyleBackColor = false;
            this.btn2000.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btn1000
            // 
            this.btn1000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.btn1000.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1000.FlatAppearance.BorderSize = 0;
            this.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1000.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btn1000.Location = new System.Drawing.Point(330, 460);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(130, 50);
            this.btn1000.TabIndex = 9;
            this.btn1000.Text = "RD$ 1,000";
            this.btn1000.UseVisualStyleBackColor = false;
            this.btn1000.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btn500
            // 
            this.btn500.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.btn500.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn500.FlatAppearance.BorderSize = 0;
            this.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn500.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.btn500.Location = new System.Drawing.Point(187, 460);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(130, 50);
            this.btn500.TabIndex = 8;
            this.btn500.Text = "RD$ 500";
            this.btn500.UseVisualStyleBackColor = false;
            this.btn500.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // btnExacto
            // 
            this.btnExacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.btnExacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExacto.FlatAppearance.BorderSize = 0;
            this.btnExacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExacto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExacto.ForeColor = System.Drawing.Color.Gray;
            this.btnExacto.Location = new System.Drawing.Point(44, 460);
            this.btnExacto.Name = "btnExacto";
            this.btnExacto.Size = new System.Drawing.Size(130, 50);
            this.btnExacto.TabIndex = 7;
            this.btnExacto.Text = "EXACTO";
            this.btnExacto.UseVisualStyleBackColor = false;
            this.btnExacto.Click += new System.EventHandler(this.btnRapido_Click);
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.txtMontoRecibido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.txtMontoRecibido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(110)))), ((int)(((byte)(42)))));
            this.txtMontoRecibido.Location = new System.Drawing.Point(44, 370);
            this.txtMontoRecibido.Multiline = true;
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(560, 80);
            this.txtMontoRecibido.TabIndex = 6;
            this.txtMontoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoRecibido.TextChanged += new System.EventHandler(this.txtMontoRecibido_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(40, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "RECIBIDO DEL CLIENTE";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.cmbMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(44, 270);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(560, 45);
            this.cmbMetodoPago.TabIndex = 4;
            this.cmbMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoPago_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(40, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "MÉTODO DE PAGO";
            // 
            // lblTotalPagando
            // 
            this.lblTotalPagando.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagando.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.lblTotalPagando.Location = new System.Drawing.Point(40, 140);
            this.lblTotalPagando.Name = "lblTotalPagando";
            this.lblTotalPagando.Size = new System.Drawing.Size(560, 80);
            this.lblTotalPagando.TabIndex = 2;
            this.lblTotalPagando.Text = "RD$ 0.00";
            this.lblTotalPagando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(40, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOTAL A PAGAR";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(17)))), ((int)(((byte)(40)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(648, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(648, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "COBRO EN CAJA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(650, 750);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobro";
            this.Load += new System.EventHandler(this.frmCobro_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalPagando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMontoRecibido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExacto;
        private System.Windows.Forms.Button btn2000;
        private System.Windows.Forms.Button btn1000;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblTextoDevuelta;
        private System.Windows.Forms.Label lblDevuelta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCobrar;
    }
}