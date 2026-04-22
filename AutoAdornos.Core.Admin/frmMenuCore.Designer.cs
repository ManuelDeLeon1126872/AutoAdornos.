namespace AutoAdornos.Core.Admin
{
    partial class frmMenuCore
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
            btnUsuarios = new Button();
            btnSucursales = new Button();
            btnProductos = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(203, 40);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(75, 23);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "btnUsuario";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnSucursales
            // 
            btnSucursales.Location = new Point(312, 40);
            btnSucursales.Name = "btnSucursales";
            btnSucursales.Size = new Size(75, 23);
            btnSucursales.TabIndex = 1;
            btnSucursales.Text = "btnSucursales";
            btnSucursales.UseVisualStyleBackColor = true;
            btnSucursales.Click += btnSucursales_Click;
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(420, 40);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(75, 23);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "btnProductos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(515, 40);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "btnSalir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmMenuCore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnProductos);
            Controls.Add(btnSucursales);
            Controls.Add(btnUsuarios);
            Name = "frmMenuCore";
            Text = "frmMenuCore";
            ResumeLayout(false);
        }

        #endregion

        private Button btnUsuarios;
        private Button btnSucursales;
        private Button btnProductos;
        private Button btnSalir;
    }
}