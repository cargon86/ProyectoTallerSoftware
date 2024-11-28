using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Empleados
{
    public partial class EmpleadoControl : UserControl
    {
        private Conexion conexion = new Conexion();
        private string usuario = "";

        public EmpleadoControl(string usuario)
        {
            InitializeComponent();
            Txtid.KeyPress += Txtid_KeyPress;
            this.usuario = usuario;
        }

        private void EmpleadoControl_Load(object sender, EventArgs e)
        {
            LlenarComboArea();
            LlenarComboUsuarios();
            CargarEmpleados();
        }

        private void LlenarComboUsuarios()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                conexion.OpenConnection(connection);
                using (SqlCommand command = new SqlCommand("ObtenerUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                using (SqlCommand command = new SqlCommand("ObtenerAreas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cbxarea.Items.Add(new KeyValuePair<int, string>(
                                Convert.ToInt32(reader["id_area"]),
                                reader["nom_area"].ToString()));
                        }
                    }
                }
                conexion.CloseConnection(connection);
            }

            Cbxarea.DisplayMember = "Value";
            Cbxarea.ValueMember = "Key";
        }

        private void CargarEmpleados()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                conexion.OpenConnection(connection);
                using (SqlCommand command = new SqlCommand("ObtenerEmpleadosEmp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                                Txtnom.Text = reader["nom_emp"].ToString();
                                Cbxusu.SelectedItem = reader["nom_usu"].ToString();

                                int idArea = Convert.ToInt32(reader["id_area"]);
                                foreach (KeyValuePair<int, string> area in Cbxarea.Items)
                                {
                                    if (area.Key == idArea)
                                    {
                                        Cbxarea.SelectedItem = area;
                                        break;
                                    }
                                }

                                bool estadoEmpleado = Convert.ToBoolean(reader["est_emp"]);
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

        private void AgregarEmpleado()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                try
                {
                    conexion.OpenConnection(connection);
                    using (SqlCommand command = new SqlCommand("AgregarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_emp", Txtid.Text);
                        command.Parameters.AddWithValue("@nom_emp", Txtnom.Text);
                        command.Parameters.AddWithValue("@nom_usu", Cbxusu.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@id_area", ((KeyValuePair<int, string>)Cbxarea.SelectedItem).Key);
                        command.Parameters.AddWithValue("@est_emp", ObtenerEstadoEmpleado());

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Empleado agregado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el empleado: " + ex.Message);
                }
                finally
                {
                    conexion.CloseConnection(connection);
                }
            }

            CargarEmpleados();
            LimpiarControles();
        }

        private void EliminarEmpleado(string idEmpleado)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                try
                {
                    conexion.OpenConnection(connection);
                    using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_emp", idEmpleado);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Empleado eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
                }
                finally
                {
                    conexion.CloseConnection(connection);
                }
            }

            CargarEmpleados();
            LimpiarControles();
        }

        private void EditarEmpleado(string idEmpleado)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                try
                {
                    conexion.OpenConnection(connection);
                    using (SqlCommand command = new SqlCommand("EditarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id_emp", idEmpleado);
                        command.Parameters.AddWithValue("@nom_emp", Txtnom.Text);
                        command.Parameters.AddWithValue("@nom_usu", Cbxusu.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@id_area", ((KeyValuePair<int, string>)Cbxarea.SelectedItem).Key);
                        command.Parameters.AddWithValue("@est_emp", ObtenerEstadoEmpleado());

                        command.ExecuteNonQuery();

                        MessageBox.Show("Empleado actualizado correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar el empleado: " + ex.Message);
                }
                finally
                {
                    conexion.CloseConnection(connection);
                }
            }

            CargarEmpleados();
            LimpiarControles();
        }

        private int ObtenerEstadoEmpleado()
        {
            return Rbtna.Checked ? 1 : 0;
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
            if (string.IsNullOrWhiteSpace(Txtid.Text) || string.IsNullOrWhiteSpace(Txtnom.Text) ||
                Cbxusu.SelectedItem == null || Cbxarea.SelectedItem == null)
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }
            AgregarEmpleado();
            CargarEmpleados();
            LimpiarControles();
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            if (Dgvempleados.SelectedRows.Count > 0)
            {
                string idEmp = Dgvempleados.SelectedRows[0].Cells["ID"].Value.ToString();
                EliminarEmpleado(idEmp);
                CargarEmpleados();
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado.");
            }
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            if (Dgvempleados.SelectedRows.Count > 0)
            {
                string idEmp = Dgvempleados.SelectedRows[0].Cells["ID"].Value.ToString();
                EditarEmpleado(idEmp);
                CargarEmpleados();
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado.");
            }
        }
    }
}
