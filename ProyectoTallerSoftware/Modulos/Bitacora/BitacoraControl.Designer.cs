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
            this.lbCambios.Location = new System.Drawing.Point(114, 29);
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
            // BitacoraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
