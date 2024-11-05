namespace ProyectoTallerSoftware.Modulos.Reportes
{
    partial class ReporteMantenimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sis_InventarioDataSet1 = new ProyectoTallerSoftware.Sis_InventarioDataSet1();
            this.obtenerProductosMantenimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerProductosMantenimientoTableAdapter = new ProyectoTallerSoftware.Sis_InventarioDataSet1TableAdapters.ObtenerProductosMantenimientoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosMantenimientoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerProductosMantenimientoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoTallerSoftware.ReporteMantenimiento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sis_InventarioDataSet1
            // 
            this.sis_InventarioDataSet1.DataSetName = "Sis_InventarioDataSet1";
            this.sis_InventarioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerProductosMantenimientoBindingSource
            // 
            this.obtenerProductosMantenimientoBindingSource.DataMember = "ObtenerProductosMantenimiento";
            this.obtenerProductosMantenimientoBindingSource.DataSource = this.sis_InventarioDataSet1;
            // 
            // obtenerProductosMantenimientoTableAdapter
            // 
            this.obtenerProductosMantenimientoTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteMantenimiento";
            this.Text = "ReporteMantenimiento";
            this.Load += new System.EventHandler(this.ReporteMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosMantenimientoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Sis_InventarioDataSet1 sis_InventarioDataSet1;
        private System.Windows.Forms.BindingSource obtenerProductosMantenimientoBindingSource;
        private Sis_InventarioDataSet1TableAdapters.ObtenerProductosMantenimientoTableAdapter obtenerProductosMantenimientoTableAdapter;
    }
}