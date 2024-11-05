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
    public partial class ReporteAseo : Form
    {
        public ReporteAseo()
        {
            InitializeComponent();
        }

        private void ReporteAseo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet1.ObtenerProductosAseo' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosAseoTableAdapter.Fill(this.sis_InventarioDataSet1.ObtenerProductosAseo);

            this.reportViewer1.RefreshReport();
        }
    }
}
