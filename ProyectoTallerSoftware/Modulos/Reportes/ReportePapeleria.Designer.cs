﻿namespace ProyectoTallerSoftware.Modulos.Reportes
{
    partial class ReportePapeleria
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_regresar = new System.Windows.Forms.Button();
            this.sis_InventarioDataSet = new ProyectoTallerSoftware.Sis_InventarioDataSet();
            this.obtenerProductosPapeleriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerProductosPapeleriaTableAdapter = new ProyectoTallerSoftware.Sis_InventarioDataSetTableAdapters.ObtenerProductosPapeleriaTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosPapeleriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerProductosPapeleriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoTallerSoftware.ReportePapeleria.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1102, 629);
            this.reportViewer1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.btn_regresar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 58);
            this.panel1.TabIndex = 6;
            // 
            // btn_regresar
            // 
            this.btn_regresar.Location = new System.Drawing.Point(20, 17);
            this.btn_regresar.Name = "btn_regresar";
            this.btn_regresar.Size = new System.Drawing.Size(75, 23);
            this.btn_regresar.TabIndex = 0;
            this.btn_regresar.Text = "Regresar";
            this.btn_regresar.UseVisualStyleBackColor = true;
            this.btn_regresar.Click += new System.EventHandler(this.Btn_regresar_Click);
            // 
            // sis_InventarioDataSet
            // 
            this.sis_InventarioDataSet.DataSetName = "Sis_InventarioDataSet";
            this.sis_InventarioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerProductosPapeleriaBindingSource
            // 
            this.obtenerProductosPapeleriaBindingSource.DataMember = "ObtenerProductosPapeleria";
            this.obtenerProductosPapeleriaBindingSource.DataSource = this.sis_InventarioDataSet;
            // 
            // obtenerProductosPapeleriaTableAdapter
            // 
            this.obtenerProductosPapeleriaTableAdapter.ClearBeforeFill = true;
            // 
            // ReportePapeleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "ReportePapeleria";
            this.Size = new System.Drawing.Size(1102, 684);
            this.Load += new System.EventHandler(this.ReportePapeleria_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosPapeleriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.BindingSource obtenerProductosPapeleriaBindingSource;
        private Sis_InventarioDataSet sis_InventarioDataSet;
        private Sis_InventarioDataSetTableAdapters.ObtenerProductosPapeleriaTableAdapter obtenerProductosPapeleriaTableAdapter;
    }
}
