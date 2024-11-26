using System;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Reportes
{
    public partial class ReporteSemanal : UserControl
    {
        public ReporteSemanal()
        {
            InitializeComponent();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            if (Parent != null && Parent.Parent is ReporteControl reporteControl)
            {
                reporteControl.RegresarAReportes();
            }
        }

        private void ReporteSemanal_Load(object sender, EventArgs e)
        {
            this.obtenerProductosUltimaSemanaTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosUltimaSemana);
            this.reportViewer1.RefreshReport();
        }
    }
}
