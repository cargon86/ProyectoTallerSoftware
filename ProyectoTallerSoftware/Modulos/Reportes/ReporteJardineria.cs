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
    public partial class ReporteJardineria : Form
    {
        public ReporteJardineria()
        {
            InitializeComponent();
        }

        private void ReporteJardineria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet1.ObtenerProductosJardineria' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosJardineriaTableAdapter.Fill(this.sis_InventarioDataSet1.ObtenerProductosJardineria);

            this.reportViewer1.RefreshReport();
        }
    }
}
