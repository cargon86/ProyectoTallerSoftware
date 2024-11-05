namespace ProyectoTallerSoftware.Modulos.Adquisicion
{
    partial class AdquisicionControl
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
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.lbFechaAdq = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.dgvAdquisicion = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lbDescripP = new System.Windows.Forms.Label();
            this.lbProducto = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lbProveedor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdquisicion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(252, 175);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(237, 20);
            this.txtCantidad.TabIndex = 47;
            // 
            // lbCantidad
            // 
            this.lbCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.BackColor = System.Drawing.Color.White;
            this.lbCantidad.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbCantidad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCantidad.Location = new System.Drawing.Point(140, 170);
            this.lbCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(100, 22);
            this.lbCantidad.TabIndex = 46;
            this.lbCantidad.Text = "Cantidad:";
            // 
            // lbFechaAdq
            // 
            this.lbFechaAdq.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbFechaAdq.AutoSize = true;
            this.lbFechaAdq.BackColor = System.Drawing.Color.White;
            this.lbFechaAdq.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbFechaAdq.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbFechaAdq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbFechaAdq.Location = new System.Drawing.Point(544, 117);
            this.lbFechaAdq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFechaAdq.Name = "lbFechaAdq";
            this.lbFechaAdq.Size = new System.Drawing.Size(188, 22);
            this.lbFechaAdq.TabIndex = 45;
            this.lbFechaAdq.Text = "Fecha Adquisicion:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFecha.Location = new System.Drawing.Point(736, 120);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(228, 20);
            this.dtpFecha.TabIndex = 44;
            // 
            // cmbProducto
            // 
            this.cmbProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(252, 122);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(237, 21);
            this.cmbProducto.TabIndex = 43;
            // 
            // dgvAdquisicion
            // 
            this.dgvAdquisicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvAdquisicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdquisicion.Location = new System.Drawing.Point(144, 299);
            this.dgvAdquisicion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAdquisicion.Name = "dgvAdquisicion";
            this.dgvAdquisicion.RowHeadersWidth = 51;
            this.dgvAdquisicion.RowTemplate.Height = 24;
            this.dgvAdquisicion.Size = new System.Drawing.Size(812, 258);
            this.dgvAdquisicion.TabIndex = 42;
            this.dgvAdquisicion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdquisicion_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(102)))), ((int)(((byte)(79)))));
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminar.Location = new System.Drawing.Point(866, 247);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 37);
            this.btnEliminar.TabIndex = 41;
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
            this.btnActualizar.Location = new System.Drawing.Point(757, 246);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 37);
            this.btnActualizar.TabIndex = 40;
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
            this.btnGuardar.Location = new System.Drawing.Point(656, 246);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 37);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.Location = new System.Drawing.Point(708, 66);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(228, 20);
            this.txtObservacion.TabIndex = 38;
            // 
            // lbDescripP
            // 
            this.lbDescripP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescripP.AutoSize = true;
            this.lbDescripP.BackColor = System.Drawing.Color.White;
            this.lbDescripP.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbDescripP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbDescripP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescripP.Location = new System.Drawing.Point(544, 62);
            this.lbDescripP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescripP.Name = "lbDescripP";
            this.lbDescripP.Size = new System.Drawing.Size(158, 22);
            this.lbDescripP.TabIndex = 37;
            this.lbDescripP.Text = "Observaciones:";
            // 
            // lbProducto
            // 
            this.lbProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbProducto.AutoSize = true;
            this.lbProducto.BackColor = System.Drawing.Color.White;
            this.lbProducto.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProducto.Location = new System.Drawing.Point(140, 117);
            this.lbProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProducto.Name = "lbProducto";
            this.lbProducto.Size = new System.Drawing.Size(103, 22);
            this.lbProducto.TabIndex = 36;
            this.lbProducto.Text = "Producto:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProveedor.BackColor = System.Drawing.Color.White;
            this.txtProveedor.Location = new System.Drawing.Point(252, 66);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(237, 20);
            this.txtProveedor.TabIndex = 35;
            // 
            // lbProveedor
            // 
            this.lbProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbProveedor.AutoSize = true;
            this.lbProveedor.BackColor = System.Drawing.Color.White;
            this.lbProveedor.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProveedor.Location = new System.Drawing.Point(140, 66);
            this.lbProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProveedor.Name = "lbProveedor";
            this.lbProveedor.Size = new System.Drawing.Size(115, 22);
            this.lbProveedor.TabIndex = 34;
            this.lbProveedor.Text = "Proveedor:";
            // 
            // AdquisicionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lbCantidad);
            this.Controls.Add(this.lbFechaAdq);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.dgvAdquisicion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lbDescripP);
            this.Controls.Add(this.lbProducto);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.lbProveedor);
            this.Name = "AdquisicionControl";
            this.Size = new System.Drawing.Size(1110, 667);
            this.Load += new System.EventHandler(this.AdquisicionControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdquisicion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.Label lbFechaAdq;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.DataGridView dgvAdquisicion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lbDescripP;
        private System.Windows.Forms.Label lbProducto;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lbProveedor;
    }
}
