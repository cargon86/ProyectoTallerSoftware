using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
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

        private void LeerBitacora(string filtroUsuario = "")
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetBitacora", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@filtroUsuario",
                    string.IsNullOrWhiteSpace(filtroUsuario) ? DBNull.Value : (object)filtroUsuario);

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


       

        private void txtFiltroUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string filtroUsuario = txtFiltroUsuario.Text.Trim();
                LeerBitacora(filtroUsuario);
            }
        }

      

        private void txtFiltroUsuario_TextChanged_1(object sender, EventArgs e)
        {
            string filtroUsuario = txtFiltroUsuario.Text.Trim();
            LeerBitacora(filtroUsuario);
        }
    }
}
