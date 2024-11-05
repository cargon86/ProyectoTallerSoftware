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
    public partial class ReporteSemanal : Form
    {
        public ReporteSemanal()
        {
            InitializeComponent();
        }

        private void ReporteSemanal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet.ObtenerProductosUltimaSemana' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosUltimaSemanaTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosUltimaSemana);

            this.reportViewer1.RefreshReport();
        }
    }
}
