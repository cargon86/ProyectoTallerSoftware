using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;



namespace ProyectoTallerSoftware.Modulos.Hoja_Requisicion
{
    public partial class Hoja_Requisicion : Form
    {

        private readonly Conexion _conexion;

        public Hoja_Requisicion()
        {
            InitializeComponent();
            _conexion = new Conexion();
        }

        private void LoadEmpleados()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("ObtenerEmpleados", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();

               
                var listaEmpleados = new List<object>();

                while (reader.Read())
                {
                    listaEmpleados.Add(new
                    {
                        id_emp = reader["id_emp"].ToString(),       
                        nom_emp = reader["nom_emp"].ToString()      
                    });
                }


                cmbSolicitante.DataSource = listaEmpleados;
                cmbSolicitante.DisplayMember = "nom_emp";  
                cmbSolicitante.ValueMember = "id_emp";     

                cmbRecibido.DataSource = listaEmpleados.ToList(); 
                cmbRecibido.ValueMember = "id_emp";


                if (listaEmpleados.Count == 0)
                {
                    MessageBox.Show("No se encontraron empleados.");
                }

                reader.Close();
                _conexion.CloseConnection(conn);
            }
        }


        private void LoadProductos()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

            
                _conexion.OpenConnection(conn);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable productosTable = new DataTable();

                adapter.Fill(productosTable);


                dgvProductosHR.DataSource = productosTable;


                _conexion.CloseConnection(conn);
            }
        }



        private void LoadUsuarios()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbSolicitud.Items.Clear(); 

                while (reader.Read())
                {

                    cmbSolicitud.Items.Add(new
                    {
                        Text = reader["Nombre de Usuario"].ToString(), 
                        Value = reader["Rol"].ToString()              
                    });
                }

                cmbSolicitud.DisplayMember = "Text"; 
                cmbSolicitud.ValueMember = "Value";   

                reader.Close();
                _conexion.CloseConnection(conn);
            }
        }

        private void LoadAreas()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetAreas", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbUnidadD.Items.Clear();

                while (reader.Read())
                {

                    cmbUnidadD.Items.Add(new
                    {
                        Text = reader["Nombre de Área"].ToString(), 
                        Value = reader["ID"].ToString()             
                    });
                }

                cmbUnidadD.DisplayMember = "Text"; 
                cmbUnidadD.ValueMember = "Value";   

                reader.Close();
                _conexion.CloseConnection(conn);
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
            Hoja_Requisicion requisicionform = new Hoja_Requisicion();
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

        private void ConfigurarDgvCarrito()
        {
            dgvCarrito.Columns.Clear();

            DataGridViewTextBoxColumn colIdProducto = new DataGridViewTextBoxColumn
            {
                Name = "id_prod",
                HeaderText = "ID Producto",
                ReadOnly = true
            };
            dgvCarrito.Columns.Add(colIdProducto);

            DataGridViewTextBoxColumn colNombreProducto = new DataGridViewTextBoxColumn
            {
                Name = "nom_prod",
                HeaderText = "Nombre Producto",
                ReadOnly = true
            };
            dgvCarrito.Columns.Add(colNombreProducto);

            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn
            {
                Name = "cantidad",
                HeaderText = "Cantidad",
                ValueType = typeof(int),
                ReadOnly = false
            };
            dgvCarrito.Columns.Add(colCantidad);

            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void LimpiarCampos()
        {
     
            cmbSolicitante.SelectedIndex = -1;
            cmbSolicitud.SelectedIndex = -1;
            cmbRecibido.SelectedIndex = -1;

    
            cmbSolicitante.SelectedIndex = -1;
            cmbRecibido.SelectedIndex = -1;


            dtpSolicitud.Value = DateTime.Now;
            dtpEntrega.Value = DateTime.Now;

      
            if (dgvProductosHR.DataSource != null)
            {
                dgvProductosHR.DataSource = null;
            }
            else
            {
                dgvProductosHR.Rows.Clear();
            }
        }

        private void Hoja_Requisicion_Load(object sender, EventArgs e)
        {
            ConfigurarDgvCarrito();
            LoadEmpleados();
            LoadUsuarios();
            LoadAreas();
            LoadProductos();
        }

        private void CargarProductosFiltrados(string searchTerm)
        {
            Conexion conexion = new Conexion();
            SqlConnection connection = conexion.GetConnection();

            if (connection != null)
            {
                try
                {
                    conexion.OpenConnection(connection);
                    using (SqlCommand command = new SqlCommand("sp_CargarProductosFiltered", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@searchTerm", searchTerm);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvProductosHR.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos filtrados: " + ex.Message);
                }
                finally
                {
                 
                    conexion.CloseConnection(connection);
                }
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión con la base de datos.");
            }
        }

        private void dgvProductosHR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvProductosHR.Rows[e.RowIndex];
                string idProducto = selectedRow.Cells["id_prod"].Value.ToString();
                string nombreProducto = selectedRow.Cells["nom_prod"].Value.ToString();

                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    if (row.Cells["id_prod"].Value?.ToString() == idProducto)
                    {
                        MessageBox.Show("Este producto ya está en el carrito.");
                        return;
                    }
                }

                dgvCarrito.Rows.Add(idProducto, nombreProducto, "");
            }
        }

      
        private void dgvCarrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCarrito.Columns[e.ColumnIndex].Name == "cantidad")
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()) ||
                    !int.TryParse(e.FormattedValue.ToString(), out int cantidad) ||
                    cantidad <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un número entero positivo en la cantidad.");
                    e.Cancel = true;
                }
            }
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text;
            CargarProductosFiltrados(searchTerm);

        }

        private void btnGuardarHR_Click(object sender, EventArgs e)
        {

            string id_emp = cmbSolicitante.SelectedValue?.ToString();
            MessageBox.Show($"ID del solicitante: {id_emp}"); 
            if (string.IsNullOrEmpty(id_emp))
            {
                MessageBox.Show("Por favor, seleccione un solicitante.");
                return;
            }


            DateTime fec_sol = dtpSolicitante.Value; 
            DateTime? fec_rec = dtpSolicitud.Checked ? dtpSolicitud.Value : (DateTime?)null; 
            DateTime? fec_ent = dtpEntrega.Checked ? dtpEntrega.Value : (DateTime?)null; 
            bool est_req = true; 


            DataTable detallesRequisicion = new DataTable();
            detallesRequisicion.Columns.Add("id_prod", typeof(int));
            detallesRequisicion.Columns.Add("cant_det", typeof(string));

 
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["id_prod"].Value != null)
                {
                    detallesRequisicion.Rows.Add(
                        Convert.ToInt32(row.Cells["id_prod"].Value),
                        row.Cells["cantidad"].Value.ToString());
                }
            }

 
            try
            {
                GuardarRequisicion(id_emp, fec_sol, fec_rec, fec_ent, est_req, detallesRequisicion);
                MessageBox.Show("Requisición guardada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la requisición: {ex.Message}");
            }

            LimpiarCampos();
        }


        private void GuardarRequisicion(string id_emp, DateTime fec_sol, DateTime? fec_rec, DateTime? fec_ent, bool estReq, DataTable detallesRequisicion)
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GuardarRequisicion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

    
                cmd.Parameters.AddWithValue("@id_emp", id_emp);
                cmd.Parameters.AddWithValue("@fec_sol", fec_sol);
                cmd.Parameters.AddWithValue("@fec_rec", (object)fec_rec ?? DBNull.Value); 
                cmd.Parameters.AddWithValue("@fec_ent", (object)fec_ent ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@est_req", estReq);


                SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@detallesRequisicion", detallesRequisicion);
                paramDetalles.SqlDbType = SqlDbType.Structured;
                paramDetalles.TypeName = "DetalleRequisicionType"; 


                _conexion.OpenConnection(conn);
                cmd.ExecuteNonQuery();
                _conexion.CloseConnection(conn);
            }
        }


    }
}
