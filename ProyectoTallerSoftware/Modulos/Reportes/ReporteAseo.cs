using System;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Reportes
{
    public partial class ReporteAseo : UserControl
    {
        public ReporteAseo()
        {
            InitializeComponent();
        }

        private void ReporteAseo_Load(object sender, EventArgs e)
        {
            try {
                this.sis_InventarioDataSet.ObtenerProductosAseo.Clear();
                this.obtenerProductosAseoTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosAseo);
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

        private void Btn_regresar_click(object sender, EventArgs e)
        {
            if (Parent != null && Parent.Parent is ReporteControl reporteControl)
            {
                reporteControl.RegresarAReportes();
            }
        }
    }
}
