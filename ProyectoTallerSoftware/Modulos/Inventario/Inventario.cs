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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ProyectoTallerSoftware.Modulos.Inventario
{
    public partial class Inventario : Form
    {
        private Conexion conexion;

        public Inventario()
        {
            InitializeComponent();
            conexion = new Conexion();
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios.Usuarios UsuariosForm = new Usuarios.Usuarios();
            UsuariosForm.Show();
            this.Hide();
        }

        private void btnRequisiciones_Click(object sender, EventArgs e)
        {
            Hoja_Requisicion.Hoja_Requisicion requisicionform = new Hoja_Requisicion.Hoja_Requisicion();
            requisicionform.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos.Productos productoform = new Productos.Productos();
            productoform.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes.Reportes ReportesForm = new Reportes.Reportes();
            ReportesForm.Show();
            this.Hide();
        }

        private void btnAdquisicion_Click(object sender, EventArgs e)
        {
            Adquisicion.Adquisicion AdquisicionForm = new Adquisicion.Adquisicion();
            AdquisicionForm.Show();
            this.Hide();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            Empleados.Empleados EmpleadosForm = new Empleados.Empleados();
            EmpleadosForm.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario InventarioForm = new Inventario();
            InventarioForm.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();


            if (string.IsNullOrEmpty(filtro))
            {
                LoadInventarioData();
            }
            else
            {
                LoadInventarioData(filtro);
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            LoadInventarioData();
        }
    }
}
