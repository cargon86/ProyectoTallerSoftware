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
    public partial class ReportePapeleria : Form
    {
        public ReportePapeleria()
        {
            InitializeComponent();
        }

        private void ReportePapeleria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet.ObtenerProductosPapeleria' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosPapeleriaTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosPapeleria);

            this.reportViewer1.RefreshReport();
        }
    }
}
