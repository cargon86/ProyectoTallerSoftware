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

namespace ProyectoTallerSoftware.Modulos.Bitacora
{
    public partial class BitacoraControl : UserControl
    {
        private readonly Conexion _conexion;
        public BitacoraControl()
        {
            InitializeComponent();
            _conexion = new Conexion();
        }

        private void BitacoraControl_Load(object sender, EventArgs e)
        {
            LeerBitacora();
        }

        private void LeerBitacora()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetBitacora", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                try
                {
                    _conexion.OpenConnection(conn);
                    adapter.Fill(dataTable);
                    dgv_bitacora.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer la bitácora: " + ex.Message);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
        }
    }
}
