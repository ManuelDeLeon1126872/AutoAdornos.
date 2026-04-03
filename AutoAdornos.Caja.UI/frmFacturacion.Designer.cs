namespace AutoAdornos.Caja.UI
{
    partial class frmFacturacion
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
            this.txtCedulaCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.btnCerrarTurno = new System.Windows.Forms.Button();
            this.btnSincronizarVentas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cedula";
            // 
            // txtCedulaCliente
            // 
            this.txtCedulaCliente.Location = new System.Drawing.Point(68, 47);
            this.txtCedulaCliente.Name = "txtCedulaCliente";
            this.txtCedulaCliente.Size = new System.Drawing.Size(181, 22);
            this.txtCedulaCliente.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(255, 47);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Producto";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(89, 145);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(181, 22);
            this.txtIdProducto.TabIndex = 4;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(276, 145);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(134, 23);
            this.btnBuscarProducto.TabIndex = 5;
            this.btnBuscarProducto.Text = "Buscar en Caché";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(49, 208);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(181, 22);
            this.txtNombreProducto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "label";
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(49, 258);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 22);
            this.numCantidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(6, 302);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(144, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar al Carrito";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(3, 399);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 16);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(175, 396);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(194, 23);
            this.btnFacturar.TabIndex = 12;
            this.btnFacturar.Text = "FACTURAR / COBRAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(977, 40);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(194, 23);
            this.btnSincronizar.TabIndex = 13;
            this.btnSincronizar.Text = "Sincronizar Catalogo";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(474, 151);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 24;
            this.dgvCarrito.Size = new System.Drawing.Size(602, 174);
            this.dgvCarrito.TabIndex = 14;
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.Location = new System.Drawing.Point(1012, 416);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Size = new System.Drawing.Size(137, 50);
            this.btnCerrarTurno.TabIndex = 15;
            this.btnCerrarTurno.Text = "CERRAR TURNO";
            this.btnCerrarTurno.UseVisualStyleBackColor = true;
            this.btnCerrarTurno.Click += new System.EventHandler(this.btnCerrarTurno_Click);
            // 
            // btnSincronizarVentas
            // 
            this.btnSincronizarVentas.Location = new System.Drawing.Point(977, 94);
            this.btnSincronizarVentas.Name = "btnSincronizarVentas";
            this.btnSincronizarVentas.Size = new System.Drawing.Size(194, 23);
            this.btnSincronizarVentas.TabIndex = 16;
            this.btnSincronizarVentas.Text = "Subir Ventas Offline";
            this.btnSincronizarVentas.UseVisualStyleBackColor = true;
            this.btnSincronizarVentas.Click += new System.EventHandler(this.btnSincronizarVentas_Click);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 546);
            this.Controls.Add(this.btnSincronizarVentas);
            this.Controls.Add(this.btnCerrarTurno);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtCedulaCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmFacturacion";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCedulaCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnCerrarTurno;
        private System.Windows.Forms.Button btnSincronizarVentas;
    }
}

