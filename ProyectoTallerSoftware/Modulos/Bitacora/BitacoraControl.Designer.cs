namespace ProyectoTallerSoftware.Modulos.Bitacora
{
    partial class BitacoraControl
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
            this.lbCambios = new System.Windows.Forms.Label();
            this.dgv_bitacora = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltroUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCambios
            // 
            this.lbCambios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCambios.AutoSize = true;
            this.lbCambios.BackColor = System.Drawing.Color.Transparent;
            this.lbCambios.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lbCambios.ForeColor = System.Drawing.Color.Black;
            this.lbCambios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCambios.Location = new System.Drawing.Point(98, 9);
            this.lbCambios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCambios.Name = "lbCambios";
            this.lbCambios.Size = new System.Drawing.Size(274, 29);
            this.lbCambios.TabIndex = 31;
            this.lbCambios.Text = "Cambios en el Sistema";
            // 
            // dgv_bitacora
            // 
            this.dgv_bitacora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bitacora.Location = new System.Drawing.Point(90, 98);
            this.dgv_bitacora.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_bitacora.Name = "dgv_bitacora";
            this.dgv_bitacora.RowHeadersWidth = 51;
            this.dgv_bitacora.RowTemplate.Height = 24;
            this.dgv_bitacora.Size = new System.Drawing.Size(783, 341);
            this.dgv_bitacora.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(86, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 39;
            this.label1.Text = "Buscar:";
            // 
            // txtFiltroUsuario
            // 
            this.txtFiltroUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFiltroUsuario.BackColor = System.Drawing.Color.White;
            this.txtFiltroUsuario.Location = new System.Drawing.Point(174, 56);
            this.txtFiltroUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltroUsuario.Name = "txtFiltroUsuario";
            this.txtFiltroUsuario.Size = new System.Drawing.Size(556, 20);
            this.txtFiltroUsuario.TabIndex = 38;
            this.txtFiltroUsuario.TextChanged += new System.EventHandler(this.txtFiltroUsuario_TextChanged_1);
            // 
            // BitacoraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltroUsuario);
            this.Controls.Add(this.lbCambios);
            this.Controls.Add(this.dgv_bitacora);
            this.Name = "BitacoraControl";
            this.Size = new System.Drawing.Size(965, 618);
            this.Load += new System.EventHandler(this.BitacoraControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCambios;
        private System.Windows.Forms.DataGridView dgv_bitacora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltroUsuario;
    }
}
