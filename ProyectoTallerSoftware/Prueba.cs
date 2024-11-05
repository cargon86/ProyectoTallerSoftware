using Microsoft.Reporting.WinForms;
using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTallerSoftware
{
    public partial class Prueba : Form
    {

        public Prueba()
        {
            InitializeComponent();
        
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet1.ObtenerProductosJardineria' Puede moverla o quitarla según sea necesario.
            this.obtenerProductosJardineriaTableAdapter.Fill(this.sis_InventarioDataSet1.ObtenerProductosJardineria);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
