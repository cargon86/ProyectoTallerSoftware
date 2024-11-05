using System;
using ProyectoTallerSoftware.Modulos.Clases;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Empleados
{
    public partial class Empleados : Form
    {
        private Conexion conexion = new Conexion();

        public Empleados()
        {
            InitializeComponent();
            Txtid.KeyPress += Txtid_KeyPress;

        }

        private void BuscarEmpleadoPorID(string idEmpleado)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                try
                {
                    conexion.OpenConnection(connection);

                    using (SqlCommand command = new SqlCommand("ObtenerEmpleadoPorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_emp", idEmpleado);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                Txtnom.Text = reader["Nombre Empleado"].ToString();


                                string nomUsu = reader["Nombre Usuario"].ToString();
                                Cbxusu.SelectedItem = nomUsu;


                                string nomArea = reader["Nombre Area"].ToString();
                                foreach (KeyValuePair<int, string> area in Cbxarea.Items)
                                {
                                    if (area.Value == nomArea)
                                    {
                                        Cbxarea.SelectedItem = area;
                                        break;
                                    }
                                }


                                bool estadoEmpleado = Convert.ToBoolean(reader["Estado Empleado"]);
                                Rbtna.Checked = estadoEmpleado;
                                Rbtni.Checked = !estadoEmpleado;
                            }
                            else
                            {
                                MessageBox.Show("Empleado no encontrado.");
                                LimpiarControles(); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el empleado: " + ex.Message);
                }
                finally
                {
                    conexion.CloseConnection(connection);
                }
            }
        }

        private void CargarEmpleados()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                conexion.OpenConnection(connection);

                using (SqlCommand command = new SqlCommand("ObtenerEmpleadosConDetalles", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Dgvempleados.DataSource = dt;
                    }
                }

                conexion.CloseConnection(connection);
            }
        }

        private void LlenarComboUsuarios()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                conexion.OpenConnection(connection);

                using (SqlCommand command = new SqlCommand("SELECT nom_usu FROM Usuarios WHERE est_usu = 1", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cbxusu.Items.Add(reader["nom_usu"].ToString());
                        }
                    }
                }

                conexion.CloseConnection(connection);
            }
        }

        private void LlenarComboArea()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                conexion.OpenConnection(connection);

                using (SqlCommand command = new SqlCommand("SELECT id_area, nom_area FROM Area", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Cbxarea.Items.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader["id_area"]), reader["nom_area"].ToString()));
                        }
                    }
                }

                conexion.CloseConnection(connection);
            }


            Cbxarea.DisplayMember = "Value";
            Cbxarea.ValueMember = "Key";
        }

        private int ObtenerEstadoEmpleado()
        {
            if (Rbtna.Checked)
                return 1; 
            else if (Rbtni.Checked)
                return 0; 
            else
                return 0; 
        }


        private void LimpiarControles()
        {
            Txtid.Clear();
            Txtnom.Clear();
            Cbxusu.SelectedIndex = -1; 
            Cbxarea.SelectedIndex = -1; 
            Rbtna.Checked = false; 
            Rbtni.Checked = false; 
        }

        private void MostrarEmpleados()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                try
                {
                    conexion.OpenConnection(connection);

                    using (SqlCommand command = new SqlCommand("ObtenerEmpleadosConDetalles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Dgvempleados.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar los empleados: " + ex.Message);
                }
                finally
                {
                    conexion.CloseConnection(connection);
                }
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
            Empleados EmpleadosForm = new Empleados();
            EmpleadosForm.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario.Inventario InventarioForm = new Inventario.Inventario();
            InventarioForm.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }

        private void Txtid_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                BuscarEmpleadoPorID(Txtid.Text);
                e.Handled = true;
            }
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txtid.Text) ||
       string.IsNullOrWhiteSpace(Txtnom.Text) ||
       Cbxusu.SelectedItem == null ||
       Cbxarea.SelectedItem == null)
            {
                MessageBox.Show("Por favor, llene todos los campos antes de agregar un empleado.",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = conexion.GetConnection())
                {
                    conexion.OpenConnection(connection);


                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(1) FROM Empleados WHERE id_emp = @id_emp", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@id_emp", Txtid.Text);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("El ID del empleado ya existe. Por favor, use un ID diferente.",
                                            "ID Duplicado",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            return;
                        }
                    }


                    using (SqlCommand command = new SqlCommand("AgregarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_emp", Txtid.Text);
                        command.Parameters.AddWithValue("@nom_emp", Txtnom.Text);
                        command.Parameters.AddWithValue("@nom_usu", Cbxusu.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@id_area", ((KeyValuePair<int, string>)Cbxarea.SelectedItem).Key);
                        command.Parameters.AddWithValue("@est_emp", ObtenerEstadoEmpleado());

                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado agregado correctamente.");
                    }

                    conexion.CloseConnection(connection);

                    CargarEmpleados();

                    LimpiarControles();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrió un error al intentar agregar el empleado. Detalle: " + ex.Message,
                                "Error al Agregar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {

            if (Dgvempleados.SelectedRows.Count > 0)
            {

                string idEmp = Dgvempleados.SelectedRows[0].Cells["ID Empleado"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?",
                                                             "Confirmar eliminación",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = conexion.GetConnection())
                    {
                        conexion.OpenConnection(connection);

                        using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id_emp", idEmp);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Empleado eliminado correctamente.");
                        }

                        conexion.CloseConnection(connection);
                    }


                    CargarEmpleados();
                    LimpiarControles();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para eliminar.");
            }
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            if (Dgvempleados.SelectedRows.Count > 0)
            {

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas editar este empleado?",
                                                             "Confirmar edición",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {

                    string idEmp = Dgvempleados.SelectedRows[0].Cells["ID Empleado"].Value.ToString();

                    if (Cbxusu.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, selecciona un usuario.");
                        return;
                    }

                    if (Cbxarea.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, selecciona un área.");
                        return;
                    }

                    using (SqlConnection connection = conexion.GetConnection())
                    {
                        conexion.OpenConnection(connection);

                        using (SqlCommand command = new SqlCommand("ActualizarEmpleado", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@id_emp", idEmp);
                            command.Parameters.AddWithValue("@nom_emp", Txtnom.Text);
                            command.Parameters.AddWithValue("@nom_usu", Cbxusu.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@id_area", ((KeyValuePair<int, string>)Cbxarea.SelectedItem).Key);
                            command.Parameters.AddWithValue("@est_emp", ObtenerEstadoEmpleado());

                            command.ExecuteNonQuery();
                            MessageBox.Show("Empleado actualizado correctamente.");
                        }

                        conexion.CloseConnection(connection);
                    }

                    CargarEmpleados();
                    LimpiarControles();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para editar.");
            }
        }

        private void Dgvempleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgvempleados.SelectedRows.Count > 0)
            {
                var row = Dgvempleados.SelectedRows[0];
                Txtid.Text = row.Cells["ID Empleado"].Value.ToString();
                Txtnom.Text = row.Cells["Nombre Empleado"].Value.ToString();


                Cbxusu.SelectedItem = row.Cells["Nombre Usuario"].Value.ToString();

                string nombreArea = row.Cells["Nombre Area"].Value.ToString();

                foreach (KeyValuePair<int, string> area in Cbxarea.Items)
                {
                    if (area.Value == nombreArea)
                    {
                        Cbxarea.SelectedItem = area;
                        break;
                    }
                }

                if (Convert.ToBoolean(row.Cells["Estado Empleado"].Value))
                {
                    Rbtna.Checked = true; 
                    Rbtni.Checked = false; 
                }
                else
                {
                    Rbtna.Checked = false; 
                    Rbtni.Checked = true; 
                }
            }
        }

        private void Empleados_Load_1(object sender, EventArgs e)
        {
            LlenarComboArea();
            LlenarComboUsuarios();
            MostrarEmpleados();
        }
    }
}









      

