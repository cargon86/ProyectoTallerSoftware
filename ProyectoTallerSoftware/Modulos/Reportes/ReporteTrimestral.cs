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
    public partial class ReporteTrimestral : Form
    {
        public ReporteTrimestral()
        {
            InitializeComponent();
        }

        private void ReporteTrimestral_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet.ObtenerProductosUltimoTrimestre' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosUltimoTrimestreTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosUltimoTrimestre);

            this.reportViewer1.RefreshReport();
        }
    }
}
