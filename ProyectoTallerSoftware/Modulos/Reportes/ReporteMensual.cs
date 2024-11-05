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
    public partial class ReporteMensual : Form
    {
        public ReporteMensual()
        {
            InitializeComponent();
        }

        private void ReporteMensual_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet.ObtenerProductosUltimoMes' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosUltimoMesTableAdapter.Fill(this.sis_InventarioDataSet.ObtenerProductosUltimoMes);

            this.reportViewer1.RefreshReport();
        }
    }
}
