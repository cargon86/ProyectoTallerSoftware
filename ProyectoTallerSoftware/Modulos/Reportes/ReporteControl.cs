using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Reportes
{
    public partial class ReporteControl : UserControl
    {
        public ReporteControl()
        {
            InitializeComponent();
        }

        private void CambiarReportes(UserControl control)
        {
            pnl_contenedor.Controls.Clear();
            pnl_contenedor.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        public void RegresarAReportes()
        {
            pnl_contenedor.Controls.Clear();
            pnl_contenedor.Controls.AddRange(new Control[] {
                btnSemanales,
                btnMensuales,
                btnTrimestrales,
                btnAseo,
                btnPapeleria,
                btnJardineria,
                btnMantenimiento
            });
        }

        private void btnSemanales_Click(object sender, EventArgs e)
        {
            ReporteSemanal reporteSemanal = new ReporteSemanal();
            CambiarReportes(reporteSemanal);
        }

        private void btnMensuales_Click(object sender, EventArgs e)
        {
            ReporteMensual reporteMensual = new ReporteMensual();
            CambiarReportes(reporteMensual);
        }

        private void btnTrimestrales_Click(object sender, EventArgs e)
        {
            ReporteTrimestral reporteTrimestral = new ReporteTrimestral();
            CambiarReportes(reporteTrimestral);
        }
        
        private void btnAseo_Click(object sender, EventArgs e)
        {
            ReporteAseo reporteAseo = new ReporteAseo();
            CambiarReportes(reporteAseo);
        }

        private void btnPapeleria_Click(object sender, EventArgs e)
        {
            ReportePapeleria reportePapeleria = new ReportePapeleria();
            CambiarReportes(reportePapeleria);
        }

        private void btnJardineria_Click(object sender, EventArgs e)
        {
            ReporteJardineria reporteJardineria = new ReporteJardineria();
            CambiarReportes(reporteJardineria);
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            ReporteMantenimiento reporteMantenimiento = new ReporteMantenimiento();
            CambiarReportes(reporteMantenimiento);
        }
    }
}
