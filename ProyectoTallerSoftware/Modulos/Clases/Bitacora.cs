using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Clases
{
    public partial class Bitacora
    {
        private readonly Conexion _conexion;

        public Bitacora()
        {
            _conexion = new Conexion();
        }

        public void Insertar(string accion, string usuario)
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertBitacora", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom_usu", usuario);
                cmd.Parameters.AddWithValue("@acc_bita", accion);

                try
                {
                    _conexion.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar en la bitácora: " + ex.Message);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
        }
    }
}
