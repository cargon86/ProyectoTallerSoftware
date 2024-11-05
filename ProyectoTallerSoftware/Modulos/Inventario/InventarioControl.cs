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

namespace ProyectoTallerSoftware.Modulos.Inventario
{
    public partial class InventarioControl : UserControl
    {
        private Conexion conexion;
        public InventarioControl()
        {
            InitializeComponent();
            conexion = new Conexion();
            LoadInventarioData();
            txtBuscar.KeyPress += new KeyPressEventHandler(txtBuscar_KeyPress);
        }

        private void LoadInventarioData(string filtro = null)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerInventario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@filtro", filtro ?? (object)DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        conexion.OpenConnection(connection);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar datos: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string filtro = txtBuscar.Text.Trim();
                LoadInventarioData(filtro);
                e.Handled = true;
            }
        }
    }
}
