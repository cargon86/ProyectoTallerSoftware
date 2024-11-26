namespace ProyectoTallerSoftware.Modulos.Empleados
{
    partial class EmpleadoControl
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
            this.Rbtni = new System.Windows.Forms.RadioButton();
            this.Rbtna = new System.Windows.Forms.RadioButton();
            this.Txtid = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.Dgvempleados = new System.Windows.Forms.DataGridView();
            this.Txtnom = new System.Windows.Forms.TextBox();
            this.Cbxusu = new System.Windows.Forms.ComboBox();
            this.Cbxarea = new System.Windows.Forms.ComboBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.Btneliminar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.Btnagregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvempleados)).BeginInit();
            this.SuspendLayout();
            // 
            // Rbtni
            // 
            this.Rbtni.AutoSize = true;
            this.Rbtni.Location = new System.Drawing.Point(320, 217);
            this.Rbtni.Margin = new System.Windows.Forms.Padding(2);
            this.Rbtni.Name = "Rbtni";
            this.Rbtni.Size = new System.Drawing.Size(63, 17);
            this.Rbtni.TabIndex = 51;
            this.Rbtni.TabStop = true;
            this.Rbtni.Text = "Inactivo";
            this.Rbtni.UseVisualStyleBackColor = true;
            // 
            // Rbtna
            // 
            this.Rbtna.AutoSize = true;
            this.Rbtna.Location = new System.Drawing.Point(203, 217);
            this.Rbtna.Margin = new System.Windows.Forms.Padding(2);
            this.Rbtna.Name = "Rbtna";
            this.Rbtna.Size = new System.Drawing.Size(55, 17);
            this.Rbtna.TabIndex = 50;
            this.Rbtna.TabStop = true;
            this.Rbtna.Text = "Activo";
            this.Rbtna.UseVisualStyleBackColor = true;
            // 
            // Txtid
            // 
            this.Txtid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txtid.Location = new System.Drawing.Point(172, 15);
            this.Txtid.Name = "Txtid";
            this.Txtid.Size = new System.Drawing.Size(283, 20);
            this.Txtid.TabIndex = 49;
            // 
            // lbId
            // 
            this.lbId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbId.ForeColor = System.Drawing.Color.Black;
            this.lbId.Location = new System.Drawing.Point(61, 15);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(33, 21);
            this.lbId.TabIndex = 48;
            this.lbId.Text = "Id:";
            // 
            // Dgvempleados
            // 
            this.Dgvempleados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Dgvempleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgvempleados.Location = new System.Drawing.Point(42, 320);
            this.Dgvempleados.Name = "Dgvempleados";
            this.Dgvempleados.RowHeadersWidth = 51;
            this.Dgvempleados.Size = new System.Drawing.Size(909, 239);
            this.Dgvempleados.TabIndex = 47;
           // 
            // Txtnom
            // 
            this.Txtnom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txtnom.Location = new System.Drawing.Point(172, 61);
            this.Txtnom.Name = "Txtnom";
            this.Txtnom.Size = new System.Drawing.Size(283, 20);
            this.Txtnom.TabIndex = 46;
            // 
            // Cbxusu
            // 
            this.Cbxusu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cbxusu.FormattingEnabled = true;
            this.Cbxusu.Location = new System.Drawing.Point(172, 165);
            this.Cbxusu.Name = "Cbxusu";
            this.Cbxusu.Size = new System.Drawing.Size(283, 21);
            this.Cbxusu.TabIndex = 45;
            // 
            // Cbxarea
            // 
            this.Cbxarea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cbxarea.FormattingEnabled = true;
            this.Cbxarea.Location = new System.Drawing.Point(172, 112);
            this.Cbxarea.Name = "Cbxarea";
            this.Cbxarea.Size = new System.Drawing.Size(283, 21);
            this.Cbxarea.TabIndex = 44;
            // 
            // lbEstado
            // 
            this.lbEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbEstado.ForeColor = System.Drawing.Color.Black;
            this.lbEstado.Location = new System.Drawing.Point(61, 213);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(77, 21);
            this.lbEstado.TabIndex = 43;
            this.lbEstado.Text = "Estado:";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbUsuario.ForeColor = System.Drawing.Color.Black;
            this.lbUsuario.Location = new System.Drawing.Point(61, 161);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(84, 21);
            this.lbUsuario.TabIndex = 42;
            this.lbUsuario.Text = "Usuario:";
            // 
            // lbArea
            // 
            this.lbArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbArea.AutoSize = true;
            this.lbArea.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbArea.ForeColor = System.Drawing.Color.Black;
            this.lbArea.Location = new System.Drawing.Point(61, 110);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(58, 21);
            this.lbArea.TabIndex = 41;
            this.lbArea.Text = "Area:";
            // 
            // lbNombre
            // 
            this.lbNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.lbNombre.ForeColor = System.Drawing.Color.Black;
            this.lbNombre.Location = new System.Drawing.Point(61, 57);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(87, 21);
            this.lbNombre.TabIndex = 40;
            this.lbNombre.Text = "Nombre:";
            // 
            // Btneliminar
            // 
            this.Btneliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btneliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(102)))), ((int)(((byte)(79)))));
            this.Btneliminar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.Btneliminar.Location = new System.Drawing.Point(804, 187);
            this.Btneliminar.Name = "Btneliminar";
            this.Btneliminar.Size = new System.Drawing.Size(119, 40);
            this.Btneliminar.TabIndex = 39;
            this.Btneliminar.Text = "Eliminar";
            this.Btneliminar.UseVisualStyleBackColor = false;
            this.Btneliminar.Click += new System.EventHandler(this.Btneliminar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(78)))));
            this.BtnEditar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.BtnEditar.Location = new System.Drawing.Point(804, 115);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(119, 37);
            this.BtnEditar.TabIndex = 38;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click_1);
            // 
            // Btnagregar
            // 
            this.Btnagregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btnagregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(172)))), ((int)(((byte)(98)))));
            this.Btnagregar.Font = new System.Drawing.Font("Arial", 13.2F, System.Drawing.FontStyle.Bold);
            this.Btnagregar.Location = new System.Drawing.Point(804, 31);
            this.Btnagregar.Name = "Btnagregar";
            this.Btnagregar.Size = new System.Drawing.Size(119, 39);
            this.Btnagregar.TabIndex = 37;
            this.Btnagregar.Text = "Agregar";
            this.Btnagregar.UseVisualStyleBackColor = false;
            this.Btnagregar.Click += new System.EventHandler(this.Btnagregar_Click);
            // 
            // EmpleadoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Rbtni);
            this.Controls.Add(this.Rbtna);
            this.Controls.Add(this.Txtid);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.Dgvempleados);
            this.Controls.Add(this.Txtnom);
            this.Controls.Add(this.Cbxusu);
            this.Controls.Add(this.Cbxarea);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.lbArea);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.Btneliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.Btnagregar);
            this.Name = "EmpleadoControl";
            this.Size = new System.Drawing.Size(994, 661);
            this.Load += new System.EventHandler(this.EmpleadoControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgvempleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Rbtni;
        private System.Windows.Forms.RadioButton Rbtna;
        private System.Windows.Forms.TextBox Txtid;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.DataGridView Dgvempleados;
        private System.Windows.Forms.TextBox Txtnom;
        private System.Windows.Forms.ComboBox Cbxusu;
        private System.Windows.Forms.ComboBox Cbxarea;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Button Btneliminar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button Btnagregar;
    }
}
