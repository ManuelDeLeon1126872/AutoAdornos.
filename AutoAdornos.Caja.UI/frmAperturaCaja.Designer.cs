namespace AutoAdornos.Caja.UI
{
    partial class frmAperturaCaja
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
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el monto inicial (Fondo de caja):";
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Location = new System.Drawing.Point(280, 137);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(241, 22);
            this.txtMontoInicial.TabIndex = 1;
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Location = new System.Drawing.Point(332, 195);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(111, 39);
            this.btnAbrirCaja.TabIndex = 2;
            this.btnAbrirCaja.Text = "ABRIR CAJA";
            this.btnAbrirCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 448);
            this.Controls.Add(this.btnAbrirCaja);
            this.Controls.Add(this.txtMontoInicial);
            this.Controls.Add(this.label1);
            this.Name = "frmAperturaCaja";
            this.Text = "frmAperturaCaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Button btnAbrirCaja;
    }
}