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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el monto inicial (Fondo de caja):";
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoInicial.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoInicial.Location = new System.Drawing.Point(164, 164);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(200, 43);
            this.txtMontoInicial.TabIndex = 1;
            this.txtMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirCaja.FlatAppearance.BorderSize = 0;
            this.btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.Location = new System.Drawing.Point(164, 290);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(200, 45);
            this.btnAbrirCaja.TabIndex = 2;
            this.btnAbrirCaja.Text = "ABRIR CAJA";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(137, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apertura de Caja";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 449);
            this.panel1.TabIndex = 4;
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAbrirCaja);
            this.Controls.Add(this.txtMontoInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAperturaCaja";
            this.Text = "frmAperturaCaja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}