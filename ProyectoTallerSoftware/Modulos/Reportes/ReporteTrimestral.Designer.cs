﻿namespace ProyectoTallerSoftware.Modulos.Reportes
{
    partial class ReporteTrimestral
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
            this.btn_regresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sis_InventarioDataSet = new ProyectoTallerSoftware.Sis_InventarioDataSet();
            this.obtenerProductosUltimoTrimestreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerProductosUltimoTrimestreTableAdapter = new ProyectoTallerSoftware.Sis_InventarioDataSetTableAdapters.ObtenerProductosUltimoTrimestreTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosUltimoTrimestreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerProductosUltimoTrimestreBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoTallerSoftware.ReporteTrimestral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1083, 618);
            this.reportViewer1.TabIndex = 9;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.btn_regresar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 58);
            this.panel1.TabIndex = 8;
            // 
            // sis_InventarioDataSet
            // 
            this.sis_InventarioDataSet.DataSetName = "Sis_InventarioDataSet";
            this.sis_InventarioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerProductosUltimoTrimestreBindingSource
            // 
            this.obtenerProductosUltimoTrimestreBindingSource.DataMember = "ObtenerProductosUltimoTrimestre";
            this.obtenerProductosUltimoTrimestreBindingSource.DataSource = this.sis_InventarioDataSet;
            // 
            // obtenerProductosUltimoTrimestreTableAdapter
            // 
            this.obtenerProductosUltimoTrimestreTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "ReporteTrimestral";
            this.Size = new System.Drawing.Size(1083, 675);
            this.Load += new System.EventHandler(this.ReporteTrimestral_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosUltimoTrimestreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource obtenerProductosUltimoTrimestreBindingSource;
        private Sis_InventarioDataSet sis_InventarioDataSet;
        private Sis_InventarioDataSetTableAdapters.ObtenerProductosUltimoTrimestreTableAdapter obtenerProductosUltimoTrimestreTableAdapter;
    }
}
