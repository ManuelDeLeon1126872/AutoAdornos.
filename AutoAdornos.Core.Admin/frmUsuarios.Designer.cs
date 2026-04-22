namespace AutoAdornos.Core.Admin
{
    partial class frmUsuarios
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
            txtNombreUsuario = new TextBox();
            txtClave = new TextBox();
            txtNombreCompleto = new TextBox();
            btnGuardar = new Button();
            btnListar = new Button();
            btnLimpiar = new Button();
            cmbSucursal = new ComboBox();
            dgvUsuarios = new DataGridView();
            chkEstado = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(82, 42);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 0;
            txtNombreUsuario.Text = "txtNombreUsuario";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(82, 84);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(100, 23);
            txtClave.TabIndex = 1;
            txtClave.Text = "txtClave";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(82, 125);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(100, 23);
            txtNombreCompleto.TabIndex = 2;
            txtNombreCompleto.Text = "txtNombreCompleto";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(87, 192);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "btnGuardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(87, 236);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 4;
            btnListar.Text = "btnListar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(87, 274);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "btnLimpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(229, 84);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(121, 23);
            cmbSucursal.TabIndex = 6;
            cmbSucursal.Text = "cmbSucursal";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(461, 84);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(240, 150);
            dgvUsuarios.TabIndex = 7;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(87, 313);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 8;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkEstado);
            Controls.Add(dgvUsuarios);
            Controls.Add(cmbSucursal);
            Controls.Add(btnLimpiar);
            Controls.Add(btnListar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombreCompleto);
            Controls.Add(txtClave);
            Controls.Add(txtNombreUsuario);
            Name = "frmUsuarios";
            Text = "frmUsuarios";
            Load += frmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreUsuario;
        private TextBox txtClave;
        private TextBox txtNombreCompleto;
        private Button btnGuardar;
        private Button btnListar;
        private Button btnLimpiar;
        private ComboBox cmbSucursal;
        private DataGridView dgvUsuarios;
        private CheckBox chkEstado;
    }
}