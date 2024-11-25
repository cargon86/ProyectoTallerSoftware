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
            conexion = new Conexion();
            LoadEmpleadosData();
            CargarUsuarios();
            CargarAreas();
            


           
            Txtid.KeyPress += new KeyPressEventHandler(txtID_KeyPress);
            Txtid.TextChanged += new EventHandler(txtID_TextChanged);
        }

        private void LoadEmpleadosData(string idEmpleado = null)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerEmpleados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(idEmpleado))
                        command.Parameters.AddWithValue("@id_emp", idEmpleado);
                    else
                        command.Parameters.AddWithValue("@id_emp", DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        conexion.OpenConnection(connection);
                        adapter.Fill(dataTable);
                        Dgvempleados.DataSource = dataTable;
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

       
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)  
            {
                string filtro = Txtid.Text.Trim();
                if (!string.IsNullOrEmpty(filtro))
                {
                    CargarEmpleadoPorID(filtro); 
                }
                e.Handled = true;
            }
        }

        
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txtid.Text)) 
            {
                LoadEmpleadosData();
            }
        }
        private void CargarUsuarios()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    try
                    {
                        conexion.OpenConnection(connection);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Cbxusu.Items.Add(reader["nom_usu"].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }

        private void CargarAreas()
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerAreas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    try
                    {
                        conexion.OpenConnection(connection);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Cbxarea.Items.Add(reader["nom_area"].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar áreas: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }

        private void CargarEmpleadoPorID(string idEmpleado)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerEmpleadoPorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@id_emp", idEmpleado);

                    try
                    {
                        conexion.OpenConnection(connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read()) 
                        {
                            Txtnom.Text = reader["nom_emp"].ToString();
                            Cbxusu.SelectedItem = reader["nom_usu"].ToString();
                            Cbxarea.SelectedItem = ObtenerNombreAreaPorId(Convert.ToInt32(reader["id_area"]));
                            bool estadoEmpleado = Convert.ToBoolean(reader["est_emp"]);
                            Rbtna.Checked = estadoEmpleado; 
                            Rbtni.Checked = !estadoEmpleado; 
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado con el ID proporcionado.");
                            LimpiarCampos(); 
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar datos del empleado: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }

        private string ObtenerNombreAreaPorId(int idArea)
        {
            string nombreArea = string.Empty;
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerNombreAreaPorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@id_area", idArea);

                    try
                    {
                        conexion.OpenConnection(connection);
                        nombreArea = command.ExecuteScalar()?.ToString(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener el nombre del área: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
            return nombreArea;
        }


        private void Btnagregar_Click(object sender, EventArgs e)
        {
            string idEmpleado = Txtid.Text.Trim();
            string nombreEmpleado = Txtnom.Text.Trim();
            string nombreUsuario = Cbxusu.SelectedItem?.ToString();
            string nombreArea = Cbxarea.SelectedItem?.ToString();
            bool estadoEmpleado = Rbtna.Checked; 

            if (string.IsNullOrEmpty(idEmpleado) || string.IsNullOrEmpty(nombreEmpleado) || nombreUsuario == null || nombreArea == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            
            int idArea = ObtenerIdAreaPorNombre(nombreArea);

            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("AgregarEmpleado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_emp", idEmpleado);
                    command.Parameters.AddWithValue("@nom_emp", nombreEmpleado);
                    command.Parameters.AddWithValue("@nom_usu", nombreUsuario);
                    command.Parameters.AddWithValue("@id_area", idArea);
                    command.Parameters.AddWithValue("@est_emp", estadoEmpleado);

                    try
                    {
                        conexion.OpenConnection(connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado agregado con éxito.");
                        LoadEmpleadosData(); 

                        
                        LimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar empleado: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }

        
        private int ObtenerIdAreaPorNombre(string nombreArea)
        {
            int idArea = 0;
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("ObtenerIdAreaPorNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@nombreArea", nombreArea);

                    try
                    {
                        conexion.OpenConnection(connection);
                        idArea = Convert.ToInt32(command.ExecuteScalar()); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener el ID del área: " + ex.Message);
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
            return idArea;
        }

        private void LimpiarCampos()
        {
            Txtid.Clear(); 
            Txtnom.Clear(); 
            Cbxusu.SelectedIndex = -1; 
            Cbxarea.SelectedIndex = -1; 
            Rbtna.Checked = false;
            Rbtni.Checked = false; 
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            string idEmpleado = Txtid.Text.Trim();

            
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (EmpleadoTieneReferencias(idEmpleado))
                {
                    MessageBox.Show("Este empleado no puede ser eliminado porque está relacionado con una requisición. Solo se puede editar.");
                    return; 
                }

                using (SqlConnection connection = conexion.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("EliminarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_emp", idEmpleado);

                        try
                        {
                            conexion.OpenConnection(connection);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Empleado eliminado con éxito.");
                            LoadEmpleadosData(); 

                            // Limpiar los campos
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar empleado: " + ex.Message);
                        }
                        finally
                        {
                            conexion.CloseConnection(connection);
                        }
                    }
                }
            }
        }
        
        private bool EmpleadoTieneReferencias(string idEmpleado)
        {
            using (SqlConnection connection = conexion.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("VerificarReferencias", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@id_emp", idEmpleado);
                    try
                    {
                        conexion.OpenConnection(connection);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar referencias: " + ex.Message);
                        return false; 
                    }
                    finally
                    {
                        conexion.CloseConnection(connection);
                    }
                }
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            string idEmpleado = Txtid.Text.Trim();
            string nombreEmpleado = Txtnom.Text.Trim();
            string nombreUsuario = Cbxusu.SelectedItem?.ToString();
            string nombreArea = Cbxarea.SelectedItem?.ToString();
            bool estadoEmpleado = Rbtna.Checked; 

            if (string.IsNullOrEmpty(idEmpleado) || string.IsNullOrEmpty(nombreEmpleado) || nombreUsuario == null || nombreArea == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea modificar este empleado?", "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int idArea = ObtenerIdAreaPorNombre(nombreArea);

                using (SqlConnection connection = conexion.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("EditarEmpleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id_emp", idEmpleado);
                        command.Parameters.AddWithValue("@nom_emp", nombreEmpleado);
                        command.Parameters.AddWithValue("@nom_usu", nombreUsuario);
                        command.Parameters.AddWithValue("@id_area", idArea);
                        command.Parameters.AddWithValue("@est_emp", estadoEmpleado);

                        try
                        {
                            conexion.OpenConnection(connection);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Empleado editado con éxito.");
                            LoadEmpleadosData(); 

                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al editar empleado: " + ex.Message);
                        }
                        finally
                        {
                            conexion.CloseConnection(connection);
                        }
                    }
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

        private void Dgvempleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}











