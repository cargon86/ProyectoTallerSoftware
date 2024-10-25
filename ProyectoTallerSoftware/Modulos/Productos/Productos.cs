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

namespace ProyectoTallerSoftware.Modulos.Productos
{

    public partial class Productos : Form
    {
        private readonly Conexion _conexion;
        public Productos()
        {
            InitializeComponent();
            _conexion = new Conexion();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis_InventarioDataSet.Productos' Puede moverla o quitarla según sea necesario.
            LoadMeasures();
            LoadProducts();
        }

        private void LoadMeasures()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetMeasures", conn); // Cambia al nombre correcto del SP para cargar medidas
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbMedida.Items.Clear(); // Limpia el ComboBox antes de cargar
                while (reader.Read())
                {
                    cmbMedida.Items.Add(new
                    {
                        Text = reader["nom_med"].ToString(), // Cambia según tu base de datos
                        Value = reader["id_med"].ToString()
                    });
                }

                cmbMedida.DisplayMember = "Text";
                cmbMedida.ValueMember = "Value";
                _conexion.CloseConnection(conn);
            }
        }

        private void LoadProducts()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;

                // Opcional: Ajustar las columnas visibles en el DataGridView
                dgvProductos.Columns["id_prod"].Visible = false; // Oculta el ID si no es necesario mostrarlo
                _conexion.CloseConnection(conn);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (ValidateFields())
            {
                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_AddProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Asegúrate de que estos nombres coincidan con los parámetros del SP
                    cmd.Parameters.AddWithValue("@NomProd", txtProducto.Text);
                    cmd.Parameters.AddWithValue("@DesProd", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@IdMed", ((dynamic)cmbMedida.SelectedItem).Value);

                    try
                    {
                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _conexion.CloseConnection(conn);
                    }
                }
                LoadProducts(); // Actualiza la lista después de agregar
                ClearFields(); // Limpia los campos después de guardar
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateFields())
            {
                int selectedId = (int)dgvProductos.CurrentRow.Cells["id_prod"].Value;

                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProd", selectedId);
                    cmd.Parameters.AddWithValue("@NomProd", txtProducto.Text);
                    cmd.Parameters.AddWithValue("@DesProd", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@IdMed", ((dynamic)cmbMedida.SelectedItem).Value);

                    _conexion.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                    _conexion.CloseConnection(conn);
                }
                LoadProducts(); // Actualiza la lista después de actualizar
                ClearFields(); // Limpia los campos después de actualizar
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvProductos.CurrentRow.Cells["id_prod"].Value;

                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProd", selectedId);

                    _conexion.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                    _conexion.CloseConnection(conn);
                }
                LoadProducts(); // Actualiza la lista después de eliminar
            }

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                // Verifica si el valor no es nulo antes de asignar
                txtProducto.Text = dgvProductos.CurrentRow.Cells["nom_prod"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["des_prod"].Value.ToString();

                // Para el ComboBox de Medida
                var selectedIdMed = dgvProductos.CurrentRow.Cells["id_med"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedIdMed))
                {
                    cmbMedida.SelectedItem = cmbMedida.Items.Cast<dynamic>().FirstOrDefault(item => item.Value == selectedIdMed);
                }
                else
                {
                    cmbMedida.SelectedIndex = -1; // Desseleccionar si el valor es nulo o vacío
                }
            }
        }

        // Método para validar los campos antes de guardar o actualizar
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMedida.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una medida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Método para limpiar los campos después de guardar o actualizar
        private void ClearFields()
        {
            txtProducto.Clear();
            txtDescripcion.Clear();
            cmbMedida.SelectedIndex = -1; // Desmarca el ComboBox
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
            Productos productoform = new Productos();
            productoform.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes.Reportes ReportesForm = new Reportes.Reportes();
            ReportesForm.Show();
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
    }
}

