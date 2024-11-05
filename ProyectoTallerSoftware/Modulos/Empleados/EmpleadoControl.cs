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
                                // Llenar los campos con los datos del empleado
                                Txtnom.Text = reader["Nombre Empleado"].ToString();

                                // Seleccionar el usuario en el ComboBox
                                string nomUsu = reader["Nombre Usuario"].ToString();
                                Cbxusu.SelectedItem = nomUsu;

                                // Seleccionar el área en el ComboBox
                                string nomArea = reader["Nombre Area"].ToString();
                                foreach (KeyValuePair<int, string> area in Cbxarea.Items)
                                {
                                    if (area.Value == nomArea)
                                    {
                                        Cbxarea.SelectedItem = area;
                                        break;
                                    }
                                }

                                // Configurar el estado del empleado
                                bool estadoEmpleado = Convert.ToBoolean(reader["Estado Empleado"]);
                                Rbtna.Checked = estadoEmpleado;
                                Rbtni.Checked = !estadoEmpleado;
                            }
                            else
                            {
                                MessageBox.Show("Empleado no encontrado.");
                                LimpiarControles(); // Limpiar controles si no se encuentra el empleado
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
                return 1; // Activo
            else if (Rbtni.Checked)
                return 0; // Inactivo
            else
                return 0; // Valor predeterminado
        }

        private void LimpiarControles()
        {
            Txtid.Clear();
            Txtnom.Clear();
            Cbxusu.SelectedIndex = -1; // Deseleccionar ComboBox de usuarios
            Cbxarea.SelectedIndex = -1; // Deseleccionar ComboBox de áreas
            Rbtna.Checked = false; // Limpiar RadioButton Activo
            Rbtni.Checked = false; // Limpiar RadioButton Inactivo
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
        private void Txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Detectar si se presionó la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {

                BuscarEmpleadoPorID(Txtid.Text);
                e.Handled = true;
            }
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txtid.Text) || string.IsNullOrWhiteSpace(Txtnom.Text) || Cbxusu.SelectedItem == null || Cbxarea.SelectedItem == null)
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

                    // Verificar si el ID ya existe
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
                        Clases.Bitacora bitacora = new Clases.Bitacora();
                        bitacora.Insertar("Se agregó un empleado con nombre " + Txtnom.Text, usuario);
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
            // Verificar que se ha seleccionado un empleado en el DataGridView
            if (Dgvempleados.SelectedRows.Count > 0)
            {
                // Obtener el ID del empleado seleccionado
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
                            Clases.Bitacora bitacora = new Clases.Bitacora();
                            bitacora.Insertar("Se actualizó un empleado con nombre " + Txtnom.Text, usuario);
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
                    // Obtener el ID del empleado seleccionado
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
                            Clases.Bitacora bitacora = new Clases.Bitacora();
                            bitacora.Insertar("Se eliminó un empleado con nombre " + Txtnom.Text, usuario);
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

                // Seleccionar el usuario
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
                    Rbtna.Checked = true; // Activo
                    Rbtni.Checked = false; // Inactivo
                }
                else
                {
                    Rbtna.Checked = false; // Activo
                    Rbtni.Checked = true; // Inactivo
                }
            }
        }
    }
}
