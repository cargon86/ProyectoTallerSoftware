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
    public partial class ReporteMantenimiento : Form
    {
        public ReporteMantenimiento()
        {
            InitializeComponent();
        }

        private void ReporteMantenimiento_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet1.ObtenerProductosMantenimiento' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosMantenimientoTableAdapter.Fill(this.sis_InventarioDataSet1.ObtenerProductosMantenimiento);

            this.reportViewer1.RefreshReport();
        }
    }
}
