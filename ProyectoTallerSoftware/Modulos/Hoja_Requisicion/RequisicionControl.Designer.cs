namespace ProyectoTallerSoftware.Modulos.Hoja_Requisicion
{
    partial class RequisicionControl
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvProductosHR = new System.Windows.Forms.DataGridView();
            this.cmbRecibido = new System.Windows.Forms.ComboBox();
            this.cmbSolicitud = new System.Windows.Forms.ComboBox();
            this.cmbSolicitante = new System.Windows.Forms.ComboBox();
            this.cmbUnidadD = new System.Windows.Forms.ComboBox();
            this.dtpEntrega = new System.Windows.Forms.DateTimePicker();
            this.dtpSolicitud = new System.Windows.Forms.DateTimePicker();
            this.dtpSolicitante = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lbNombreP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(172)))), ((int)(((byte)(98)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardar.Location = new System.Drawing.Point(667, 788);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(211, 46);
            this.btnGuardar.TabIndex = 72;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardarHR_Click);
            // 
            // dgvProductosHR
            // 
            this.dgvProductosHR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvProductosHR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosHR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosHR.Location = new System.Drawing.Point(136, 169);
            this.dgvProductosHR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductosHR.Name = "dgvProductosHR";
            this.dgvProductosHR.RowHeadersWidth = 51;
            this.dgvProductosHR.Size = new System.Drawing.Size(1309, 142);
            this.dgvProductosHR.TabIndex = 71;
            this.dgvProductosHR.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductosHR_CellClick);
            this.dgvProductosHR.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCarrito_CellValidating);
            // 
            // cmbRecibido
            // 
            this.cmbRecibido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRecibido.DisplayMember = "nom_emp";
            this.cmbRecibido.FormattingEnabled = true;
            this.cmbRecibido.Items.AddRange(new object[] {
            "Aseo",
            "Jardineria",
            "Mantenimiento",
            "Papeleria"});
            this.cmbRecibido.Location = new System.Drawing.Point(1087, 697);
            this.cmbRecibido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbRecibido.Name = "cmbRecibido";
            this.cmbRecibido.Size = new System.Drawing.Size(304, 24);
            this.cmbRecibido.TabIndex = 70;
            this.cmbRecibido.ValueMember = "id_emp";
            // 
            // cmbSolicitud
            // 
            this.cmbSolicitud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSolicitud.FormattingEnabled = true;
            this.cmbSolicitud.Items.AddRange(new object[] {
            "Aseo",
            "Jardineria",
            "Mantenimiento",
            "Papeleria"});
            this.cmbSolicitud.Location = new System.Drawing.Point(617, 697);
            this.cmbSolicitud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSolicitud.Name = "cmbSolicitud";
            this.cmbSolicitud.Size = new System.Drawing.Size(304, 24);
            this.cmbSolicitud.TabIndex = 69;
            // 
            // cmbSolicitante
            // 
            this.cmbSolicitante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSolicitante.DisplayMember = "nom_emp";
            this.cmbSolicitante.FormattingEnabled = true;
            this.cmbSolicitante.Items.AddRange(new object[] {
            "Aseo",
            "Jardineria",
            "Mantenimiento",
            "Papeleria"});
            this.cmbSolicitante.Location = new System.Drawing.Point(153, 697);
            this.cmbSolicitante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSolicitante.Name = "cmbSolicitante";
            this.cmbSolicitante.Size = new System.Drawing.Size(304, 24);
            this.cmbSolicitante.TabIndex = 68;
            this.cmbSolicitante.ValueMember = "id_emp";
            // 
            // cmbUnidadD
            // 
            this.cmbUnidadD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbUnidadD.FormattingEnabled = true;
            this.cmbUnidadD.Items.AddRange(new object[] {
            "Aseo",
            "Jardineria",
            "Mantenimiento",
            "Papeleria"});
            this.cmbUnidadD.Location = new System.Drawing.Point(377, 118);
            this.cmbUnidadD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbUnidadD.Name = "cmbUnidadD";
            this.cmbUnidadD.Size = new System.Drawing.Size(304, 24);
            this.cmbUnidadD.TabIndex = 67;
            // 
            // dtpEntrega
            // 
            this.dtpEntrega.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpEntrega.Location = new System.Drawing.Point(1115, 734);
            this.dtpEntrega.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEntrega.Name = "dtpEntrega";
            this.dtpEntrega.Size = new System.Drawing.Size(245, 22);
            this.dtpEntrega.TabIndex = 66;
            // 
            // dtpSolicitud
            // 
            this.dtpSolicitud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpSolicitud.Location = new System.Drawing.Point(648, 735);
            this.dtpSolicitud.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSolicitud.Name = "dtpSolicitud";
            this.dtpSolicitud.Size = new System.Drawing.Size(245, 22);
            this.dtpSolicitud.TabIndex = 65;
            // 
            // dtpSolicitante
            // 
            this.dtpSolicitante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpSolicitante.Location = new System.Drawing.Point(184, 735);
            this.dtpSolicitante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSolicitante.Name = "dtpSolicitante";
            this.dtpSolicitante.Size = new System.Drawing.Size(245, 22);
            this.dtpSolicitante.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1136, 665);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 28);
            this.label4.TabIndex = 63;
            this.label4.Text = "Articulo rebido por";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(643, 665);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 28);
            this.label3.TabIndex = 62;
            this.label3.Text = "Solicitud recibida por";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 665);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 57;
            this.label2.Text = "Solicitante";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(136, 334);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.Size = new System.Drawing.Size(1309, 283);
            this.dgvCarrito.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(801, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 60;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(923, 118);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(504, 32);
            this.txtBuscar.TabIndex = 59;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            // 
            // lbNombreP
            // 
            this.lbNombreP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNombreP.AutoSize = true;
            this.lbNombreP.BackColor = System.Drawing.Color.White;
            this.lbNombreP.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbNombreP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNombreP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNombreP.Location = new System.Drawing.Point(113, 116);
            this.lbNombreP.Name = "lbNombreP";
            this.lbNombreP.Size = new System.Drawing.Size(245, 27);
            this.lbNombreP.TabIndex = 58;
            this.lbNombreP.Text = "Unidad Demandante:";
            // 
            // RequisicionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvProductosHR);
            this.Controls.Add(this.cmbRecibido);
            this.Controls.Add(this.cmbSolicitud);
            this.Controls.Add(this.cmbSolicitante);
            this.Controls.Add(this.cmbUnidadD);
            this.Controls.Add(this.dtpEntrega);
            this.Controls.Add(this.dtpSolicitud);
            this.Controls.Add(this.dtpSolicitante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lbNombreP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RequisicionControl";
            this.Size = new System.Drawing.Size(1557, 948);
            this.Load += new System.EventHandler(this.RequisicionControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvProductosHR;
        private System.Windows.Forms.ComboBox cmbRecibido;
        private System.Windows.Forms.ComboBox cmbSolicitud;
        private System.Windows.Forms.ComboBox cmbSolicitante;
        private System.Windows.Forms.ComboBox cmbUnidadD;
        private System.Windows.Forms.DateTimePicker dtpEntrega;
        private System.Windows.Forms.DateTimePicker dtpSolicitud;
        private System.Windows.Forms.DateTimePicker dtpSolicitante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lbNombreP;
    }
}
