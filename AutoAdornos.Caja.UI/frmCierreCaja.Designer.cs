namespace AutoAdornos.Caja.UI
{
    partial class frmCierreCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFondoInicial = new System.Windows.Forms.TextBox();
            this.txtTotalVendido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsperado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDineroContado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCuadrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fondo Inicial:";
            // 
            // txtFondoInicial
            // 
            this.txtFondoInicial.Location = new System.Drawing.Point(165, 51);
            this.txtFondoInicial.Name = "txtFondoInicial";
            this.txtFondoInicial.ReadOnly = true;
            this.txtFondoInicial.Size = new System.Drawing.Size(100, 22);
            this.txtFondoInicial.TabIndex = 1;
            // 
            // txtTotalVendido
            // 
            this.txtTotalVendido.Location = new System.Drawing.Point(298, 51);
            this.txtTotalVendido.Name = "txtTotalVendido";
            this.txtTotalVendido.ReadOnly = true;
            this.txtTotalVendido.Size = new System.Drawing.Size(100, 22);
            this.txtTotalVendido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Vendido:";
            // 
            // txtEsperado
            // 
            this.txtEsperado.Location = new System.Drawing.Point(429, 51);
            this.txtEsperado.Name = "txtEsperado";
            this.txtEsperado.ReadOnly = true;
            this.txtEsperado.Size = new System.Drawing.Size(156, 22);
            this.txtEsperado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto Esperado en Caja:";
            // 
            // txtDineroContado
            // 
            this.txtDineroContado.Location = new System.Drawing.Point(276, 191);
            this.txtDineroContado.Name = "txtDineroContado";
            this.txtDineroContado.Size = new System.Drawing.Size(177, 22);
            this.txtDineroContado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dinero Contado Fisicamente:";
            // 
            // btnCuadrar
            // 
            this.btnCuadrar.Location = new System.Drawing.Point(309, 258);
            this.btnCuadrar.Name = "btnCuadrar";
            this.btnCuadrar.Size = new System.Drawing.Size(104, 45);
            this.btnCuadrar.TabIndex = 8;
            this.btnCuadrar.Text = "REALIZAR CUADRE";
            this.btnCuadrar.UseVisualStyleBackColor = true;
            this.btnCuadrar.Click += new System.EventHandler(this.btnCuadrar_Click);
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCuadrar);
            this.Controls.Add(this.txtDineroContado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEsperado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalVendido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFondoInicial);
            this.Controls.Add(this.label1);
            this.Name = "frmCierreCaja";
            this.Text = "frmCierreCaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFondoInicial;
        private System.Windows.Forms.TextBox txtTotalVendido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsperado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDineroContado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCuadrar;
    }
}