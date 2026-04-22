namespace AutoAdornos.Core.Admin
{
    partial class frmProductos
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
            txtCodigo = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtExistencia = new TextBox();
            chkEstado = new CheckBox();
            btnGuardar = new Button();
            btnListar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(92, 43);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 0;
            txtCodigo.Text = "txtCodigo";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(92, 86);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.Text = "txtDescripcion";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(92, 127);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 2;
            txtPrecio.Text = "txtPrecio";
            // 
            // txtExistencia
            // 
            txtExistencia.Location = new Point(92, 171);
            txtExistencia.Name = "txtExistencia";
            txtExistencia.Size = new Size(100, 23);
            txtExistencia.TabIndex = 3;
            txtExistencia.Text = "txtExistencia";
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Location = new Point(92, 223);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 4;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(82, 261);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "btnGuardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(82, 299);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 6;
            btnListar.Text = "btnListar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(82, 340);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "btnLimpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(471, 103);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(240, 150);
            dgvProductos.TabIndex = 8;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProductos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnListar);
            Controls.Add(btnGuardar);
            Controls.Add(chkEstado);
            Controls.Add(txtExistencia);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCodigo);
            Name = "frmProductos";
            Text = "frmProductos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigo;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private TextBox txtExistencia;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnListar;
        private Button btnLimpiar;
        private DataGridView dgvProductos;
    }
}