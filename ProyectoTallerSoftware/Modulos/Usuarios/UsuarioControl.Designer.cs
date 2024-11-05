namespace ProyectoTallerSoftware.Modulos.Usuarios
{
    partial class UsuarioControl
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
            this.lb_nom_usu = new System.Windows.Forms.Label();
            this.txtb_nom_usu = new System.Windows.Forms.TextBox();
            this.dgv_usuarios = new System.Windows.Forms.DataGridView();
            this.cmb_rol_usu = new System.Windows.Forms.ComboBox();
            this.txtb_passc_usu = new System.Windows.Forms.TextBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.txtb_pass_usu = new System.Windows.Forms.TextBox();
            this.cmb_sta_usu = new System.Windows.Forms.ComboBox();
            this.lb_sta_usu = new System.Windows.Forms.Label();
            this.lb_rol_usu = new System.Windows.Forms.Label();
            this.lb_passc_usu = new System.Windows.Forms.Label();
            this.lb_pass_usu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_nom_usu
            // 
            this.lb_nom_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_nom_usu.AutoSize = true;
            this.lb_nom_usu.BackColor = System.Drawing.Color.White;
            this.lb_nom_usu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lb_nom_usu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_nom_usu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_nom_usu.Location = new System.Drawing.Point(93, 24);
            this.lb_nom_usu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_nom_usu.Name = "lb_nom_usu";
            this.lb_nom_usu.Size = new System.Drawing.Size(195, 22);
            this.lb_nom_usu.TabIndex = 42;
            this.lb_nom_usu.Text = "Nombre de Usuario:";
            // 
            // txtb_nom_usu
            // 
            this.txtb_nom_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtb_nom_usu.BackColor = System.Drawing.Color.White;
            this.txtb_nom_usu.Location = new System.Drawing.Point(331, 27);
            this.txtb_nom_usu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtb_nom_usu.Name = "txtb_nom_usu";
            this.txtb_nom_usu.Size = new System.Drawing.Size(327, 20);
            this.txtb_nom_usu.TabIndex = 41;
            // 
            // dgv_usuarios
            // 
            this.dgv_usuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_usuarios.Location = new System.Drawing.Point(97, 225);
            this.dgv_usuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_usuarios.MultiSelect = false;
            this.dgv_usuarios.Name = "dgv_usuarios";
            this.dgv_usuarios.ReadOnly = true;
            this.dgv_usuarios.RowHeadersWidth = 51;
            this.dgv_usuarios.RowTemplate.Height = 24;
            this.dgv_usuarios.Size = new System.Drawing.Size(794, 277);
            this.dgv_usuarios.TabIndex = 40;
            this.dgv_usuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_usuarios_CellClick);
            this.dgv_usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_usuarios_CellContentClick);
            // 
            // cmb_rol_usu
            // 
            this.cmb_rol_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_rol_usu.FormattingEnabled = true;
            this.cmb_rol_usu.Location = new System.Drawing.Point(331, 140);
            this.cmb_rol_usu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_rol_usu.Name = "cmb_rol_usu";
            this.cmb_rol_usu.Size = new System.Drawing.Size(183, 21);
            this.cmb_rol_usu.TabIndex = 39;
            // 
            // txtb_passc_usu
            // 
            this.txtb_passc_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtb_passc_usu.BackColor = System.Drawing.Color.White;
            this.txtb_passc_usu.Location = new System.Drawing.Point(331, 102);
            this.txtb_passc_usu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtb_passc_usu.Name = "txtb_passc_usu";
            this.txtb_passc_usu.Size = new System.Drawing.Size(327, 20);
            this.txtb_passc_usu.TabIndex = 38;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(102)))), ((int)(((byte)(79)))));
            this.btn_eliminar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btn_eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_eliminar.Location = new System.Drawing.Point(784, 123);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(107, 37);
            this.btn_eliminar.TabIndex = 37;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_actualizar.BackColor = System.Drawing.Color.Peru;
            this.btn_actualizar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btn_actualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_actualizar.Location = new System.Drawing.Point(784, 75);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(107, 37);
            this.btn_actualizar.TabIndex = 36;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = false;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(172)))), ((int)(((byte)(98)))));
            this.btn_guardar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_guardar.Location = new System.Drawing.Point(784, 27);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(107, 37);
            this.btn_guardar.TabIndex = 35;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // txtb_pass_usu
            // 
            this.txtb_pass_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtb_pass_usu.BackColor = System.Drawing.Color.White;
            this.txtb_pass_usu.Location = new System.Drawing.Point(331, 64);
            this.txtb_pass_usu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtb_pass_usu.Name = "txtb_pass_usu";
            this.txtb_pass_usu.Size = new System.Drawing.Size(327, 20);
            this.txtb_pass_usu.TabIndex = 34;
            // 
            // cmb_sta_usu
            // 
            this.cmb_sta_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_sta_usu.FormattingEnabled = true;
            this.cmb_sta_usu.Location = new System.Drawing.Point(331, 177);
            this.cmb_sta_usu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_sta_usu.Name = "cmb_sta_usu";
            this.cmb_sta_usu.Size = new System.Drawing.Size(183, 21);
            this.cmb_sta_usu.TabIndex = 33;
            // 
            // lb_sta_usu
            // 
            this.lb_sta_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_sta_usu.AutoSize = true;
            this.lb_sta_usu.BackColor = System.Drawing.Color.White;
            this.lb_sta_usu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lb_sta_usu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_sta_usu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_sta_usu.Location = new System.Drawing.Point(93, 176);
            this.lb_sta_usu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sta_usu.Name = "lb_sta_usu";
            this.lb_sta_usu.Size = new System.Drawing.Size(82, 22);
            this.lb_sta_usu.TabIndex = 32;
            this.lb_sta_usu.Text = "Estado:";
            // 
            // lb_rol_usu
            // 
            this.lb_rol_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_rol_usu.AutoSize = true;
            this.lb_rol_usu.BackColor = System.Drawing.Color.White;
            this.lb_rol_usu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lb_rol_usu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_rol_usu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_rol_usu.Location = new System.Drawing.Point(93, 138);
            this.lb_rol_usu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_rol_usu.Name = "lb_rol_usu";
            this.lb_rol_usu.Size = new System.Drawing.Size(47, 22);
            this.lb_rol_usu.TabIndex = 31;
            this.lb_rol_usu.Text = "Rol:";
            // 
            // lb_passc_usu
            // 
            this.lb_passc_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_passc_usu.AutoSize = true;
            this.lb_passc_usu.BackColor = System.Drawing.Color.White;
            this.lb_passc_usu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lb_passc_usu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_passc_usu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_passc_usu.Location = new System.Drawing.Point(93, 101);
            this.lb_passc_usu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_passc_usu.Name = "lb_passc_usu";
            this.lb_passc_usu.Size = new System.Drawing.Size(223, 22);
            this.lb_passc_usu.TabIndex = 30;
            this.lb_passc_usu.Text = "Confirmar Contraseña:";
            // 
            // lb_pass_usu
            // 
            this.lb_pass_usu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_pass_usu.AutoSize = true;
            this.lb_pass_usu.BackColor = System.Drawing.Color.White;
            this.lb_pass_usu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lb_pass_usu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_pass_usu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_pass_usu.Location = new System.Drawing.Point(93, 62);
            this.lb_pass_usu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_pass_usu.Name = "lb_pass_usu";
            this.lb_pass_usu.Size = new System.Drawing.Size(125, 22);
            this.lb_pass_usu.TabIndex = 29;
            this.lb_pass_usu.Text = "Contraseña:";
            // 
            // UsuarioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_nom_usu);
            this.Controls.Add(this.txtb_nom_usu);
            this.Controls.Add(this.dgv_usuarios);
            this.Controls.Add(this.cmb_rol_usu);
            this.Controls.Add(this.txtb_passc_usu);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.txtb_pass_usu);
            this.Controls.Add(this.cmb_sta_usu);
            this.Controls.Add(this.lb_sta_usu);
            this.Controls.Add(this.lb_rol_usu);
            this.Controls.Add(this.lb_passc_usu);
            this.Controls.Add(this.lb_pass_usu);
            this.Name = "UsuarioControl";
            this.Size = new System.Drawing.Size(1003, 666);
            this.Load += new System.EventHandler(this.UsuarioControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_nom_usu;
        private System.Windows.Forms.TextBox txtb_nom_usu;
        private System.Windows.Forms.DataGridView dgv_usuarios;
        private System.Windows.Forms.ComboBox cmb_rol_usu;
        private System.Windows.Forms.TextBox txtb_passc_usu;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.TextBox txtb_pass_usu;
        private System.Windows.Forms.ComboBox cmb_sta_usu;
        private System.Windows.Forms.Label lb_sta_usu;
        private System.Windows.Forms.Label lb_rol_usu;
        private System.Windows.Forms.Label lb_passc_usu;
        private System.Windows.Forms.Label lb_pass_usu;
    }
}
