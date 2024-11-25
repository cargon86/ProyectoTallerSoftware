using System;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Reportes
{
    public partial class ReporteJardineria : UserControl
    {
        public ReporteJardineria()
        {
            InitializeComponent();
        }

        private void ReporteJardineria_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            if (Parent != null && Parent.Parent is ReporteControl reporteControl)
            {
                reporteControl.RegresarAReportes();
            }
        }
    }
}
