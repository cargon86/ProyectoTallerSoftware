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
            this.obtenerProductosAseoTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosAseo);
            this.reportViewer1.RefreshReport();
        }

        private void btn_regresar_click(object sender, EventArgs e)
        {
            if (Parent != null && Parent.Parent is ReporteControl reporteControl)
            {
                reporteControl.RegresarAReportes();
            }
        }
    }
}
