namespace ProyectoTallerSoftware.Modulos.Productos
{
    partial class ProductoControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbDescripP = new System.Windows.Forms.Label();
            this.lbMedidaP = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lbProductoP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMedida
            // 
            this.cmbMedida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMedida.FormattingEnabled = true;
            this.cmbMedida.Location = new System.Drawing.Point(205, 87);
            this.cmbMedida.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(272, 21);
            this.cmbMedida.TabIndex = 27;
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(90, 193);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(822, 312);
            this.dgvProductos.TabIndex = 26;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(102)))), ((int)(((byte)(79)))));
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminar.Location = new System.Drawing.Point(823, 138);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 37);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(183)))));
            this.btnActualizar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnActualizar.Location = new System.Drawing.Point(702, 138);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 37);
            this.btnActualizar.TabIndex = 24;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(172)))), ((int)(((byte)(98)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardar.Location = new System.Drawing.Point(591, 138);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 37);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(655, 36);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(272, 20);
            this.txtDescripcion.TabIndex = 22;
            // 
            // lbDescripP
            // 
            this.lbDescripP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescripP.AutoSize = true;
            this.lbDescripP.BackColor = System.Drawing.Color.White;
            this.lbDescripP.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbDescripP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbDescripP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescripP.Location = new System.Drawing.Point(521, 32);
            this.lbDescripP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescripP.Name = "lbDescripP";
            this.lbDescripP.Size = new System.Drawing.Size(129, 22);
            this.lbDescripP.TabIndex = 21;
            this.lbDescripP.Text = "Descripcion:";
            // 
            // lbMedidaP
            // 
            this.lbMedidaP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMedidaP.AutoSize = true;
            this.lbMedidaP.BackColor = System.Drawing.Color.White;
            this.lbMedidaP.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbMedidaP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbMedidaP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMedidaP.Location = new System.Drawing.Point(86, 84);
            this.lbMedidaP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMedidaP.Name = "lbMedidaP";
            this.lbMedidaP.Size = new System.Drawing.Size(85, 22);
            this.lbMedidaP.TabIndex = 20;
            this.lbMedidaP.Text = "Medida:";
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProducto.BackColor = System.Drawing.Color.White;
            this.txtProducto.Location = new System.Drawing.Point(205, 36);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(272, 20);
            this.txtProducto.TabIndex = 19;
            // 
            // lbProductoP
            // 
            this.lbProductoP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbProductoP.AutoSize = true;
            this.lbProductoP.BackColor = System.Drawing.Color.White;
            this.lbProductoP.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbProductoP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbProductoP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProductoP.Location = new System.Drawing.Point(86, 31);
            this.lbProductoP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProductoP.Name = "lbProductoP";
            this.lbProductoP.Size = new System.Drawing.Size(103, 22);
            this.lbProductoP.TabIndex = 18;
            this.lbProductoP.Text = "Producto:";
            // 
            // ProductoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbMedida);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lbDescripP);
            this.Controls.Add(this.lbMedidaP);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lbProductoP);
            this.Name = "ProductoControl";
            this.Size = new System.Drawing.Size(1021, 667);
            this.Load += new System.EventHandler(this.ProductoControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lbDescripP;
        private System.Windows.Forms.Label lbMedidaP;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lbProductoP;
    }
}
