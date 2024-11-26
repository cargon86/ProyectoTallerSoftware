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
            this.lbCambios.Location = new System.Drawing.Point(131, 11);
            this.lbCambios.Name = "lbCambios";
            this.lbCambios.Size = new System.Drawing.Size(340, 35);
            this.lbCambios.TabIndex = 31;
            this.lbCambios.Text = "Cambios en el Sistema";
            // 
            // dgv_bitacora
            // 
            this.dgv_bitacora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_bitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bitacora.Location = new System.Drawing.Point(120, 121);
            this.dgv_bitacora.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_bitacora.Name = "dgv_bitacora";
            this.dgv_bitacora.RowHeadersWidth = 51;
            this.dgv_bitacora.RowTemplate.Height = 24;
            this.dgv_bitacora.Size = new System.Drawing.Size(1044, 420);
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
            this.label1.Location = new System.Drawing.Point(115, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 27);
            this.label1.TabIndex = 39;
            this.label1.Text = "Buscar:";
            // 
            // txtFiltroUsuario
            // 
            this.txtFiltroUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFiltroUsuario.BackColor = System.Drawing.Color.White;
            this.txtFiltroUsuario.Location = new System.Drawing.Point(232, 69);
            this.txtFiltroUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiltroUsuario.Name = "txtFiltroUsuario";
            this.txtFiltroUsuario.Size = new System.Drawing.Size(740, 22);
            this.txtFiltroUsuario.TabIndex = 38;
            this.txtFiltroUsuario.TextChanged += new System.EventHandler(this.txtFiltroUsuario_TextChanged_1);
            // 
            // BitacoraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltroUsuario);
            this.Controls.Add(this.lbCambios);
            this.Controls.Add(this.dgv_bitacora);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BitacoraControl";
            this.Size = new System.Drawing.Size(1287, 761);
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
