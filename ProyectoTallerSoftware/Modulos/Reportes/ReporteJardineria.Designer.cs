namespace ProyectoTallerSoftware.Modulos.Reportes
{
    partial class ReporteJardineria
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
            this.obtenerProductosJardineriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerProductosJardineriaTableAdapter = new ProyectoTallerSoftware.Sis_InventarioDataSet1TableAdapters.ObtenerProductosJardineriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosJardineriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerProductosJardineriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoTallerSoftware.ReporteJardineria.rdlc";
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
            // obtenerProductosJardineriaBindingSource
            // 
            this.obtenerProductosJardineriaBindingSource.DataMember = "ObtenerProductosJardineria";
            this.obtenerProductosJardineriaBindingSource.DataSource = this.sis_InventarioDataSet1;
            // 
            // obtenerProductosJardineriaTableAdapter
            // 
            this.obtenerProductosJardineriaTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteJardineria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteJardineria";
            this.Text = "ReporteJardineria";
            this.Load += new System.EventHandler(this.ReporteJardineria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sis_InventarioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosJardineriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Sis_InventarioDataSet1 sis_InventarioDataSet1;
        private System.Windows.Forms.BindingSource obtenerProductosJardineriaBindingSource;
        private Sis_InventarioDataSet1TableAdapters.ObtenerProductosJardineriaTableAdapter obtenerProductosJardineriaTableAdapter;
    }
}