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
    public partial class ReporteAseo : UserControl
    {
        public ReporteAseo()
        {
            InitializeComponent();
        }

        private void ReporteAseo_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btn_regresar_click(object sender, EventArgs e)
        {

        }
    }
}
