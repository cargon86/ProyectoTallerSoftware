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
    public partial class ReporteSemanal : UserControl
    {
        public ReporteSemanal()
        {
            InitializeComponent();
            this.reportViewer1.RefreshReport();
        }
    }
}
