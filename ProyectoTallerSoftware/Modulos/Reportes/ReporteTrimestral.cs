using System;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Reportes
{
    public partial class ReporteTrimestral : UserControl
    {
        public ReporteTrimestral()
        {
            InitializeComponent();
        }

        private void Btn_regresar_Click(object sender, EventArgs e)
        {
            if (Parent != null && Parent.Parent is ReporteControl reporteControl)
            {
                reporteControl.RegresarAReportes();
            }
        }

        private void ReporteTrimestral_Load(object sender, EventArgs e)
        {
            try {
                this.sis_InventarioDataSet.ObtenerProductosUltimoTrimestre?.Clear();
                this.obtenerProductosUltimoTrimestreTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosUltimoTrimestre);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Data.ConstraintException ex)
            {
                MessageBox.Show("Error al cargar los datos del reporte: Hay registros que no cumplen con las restricciones de la base de datos.\n\n" +
                              "Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del reporte:\n\n" + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
