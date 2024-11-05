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
using static System.Collections.Specialized.BitVector32;

namespace ProyectoTallerSoftware.Modulos.Adquisicion
{
    public partial class AdquisicionControl : UserControl
    {
        private readonly Conexion _conexion;
        private string usuario = "";
        private int selectedAdqId;
        private int selectedDetAdqId;

        public AdquisicionControl(string usuario)
        {
            InitializeComponent();
            _conexion = new Conexion();
            this.usuario = usuario;
        }

        private void AdquisicionControl_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadDetalleAdquisicion();
        }

        private void LoadProducts()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();
                cmbProducto.Items.Clear();

                while (reader.Read())
                {
                    cmbProducto.Items.Add(new
                    {
                        Text = reader["nom_prod"].ToString(),
                        Value = reader["id_prod"].ToString()
                    });
                }

                cmbProducto.DisplayMember = "Text";
                cmbProducto.ValueMember = "Value";
                _conexion.CloseConnection(conn);
            }
        }

        private void LoadDetalleAdquisicion()
        {
            using (var conn = _conexion.GetConnection())
            {
                try
                {
                    _conexion.OpenConnection(conn);

                    // Crear el comando para llamar al procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("sp_GetDetalleAdquisicion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Crear un DataAdapter para llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los resultados de la consulta
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos para el DataGridView
                    dgvAdquisicion.DataSource = dataTable;

                    // Ocultar las columnas de IDs en el DataGridView para que no se muestren al usuario
                    dgvAdquisicion.Columns["id_adq"].Visible = false;
                    dgvAdquisicion.Columns["id_det_adq"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el detalle de la adquisición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
        }

        private void dgvAdquisicion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdquisicion.Rows[e.RowIndex];

                // Capturar el ID de adquisición y detalle de adquisición (si están ocultos en las columnas)
                if (int.TryParse(row.Cells["id_adq"].Value?.ToString(), out int adqId))
                {
                    selectedAdqId = adqId;
                }

                if (int.TryParse(row.Cells["id_det_adq"].Value?.ToString(), out int detAdqId))
                {
                    selectedDetAdqId = detAdqId;
                }

                // Asignar valores a los controles del formulario
                txtProveedor.Text = row.Cells["prov_adq"].Value?.ToString();
                txtCantidad.Text = row.Cells["cant_ent"].Value?.ToString();
                txtObservacion.Text = row.Cells["obs_adq"].Value?.ToString();

                if (row.Cells["fec_adq"].Value != null && DateTime.TryParse(row.Cells["fec_adq"].Value.ToString(), out DateTime fecha))
                {
                    dtpFecha.Value = fecha;
                }

                // Buscar y seleccionar el producto en el ComboBox
                var selectedProducto = row.Cells["nom_prod"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedProducto))
                {
                    var selectedItem = cmbProducto.Items.Cast<dynamic>().FirstOrDefault(item => item.Text == selectedProducto);
                    if (selectedItem != null)
                    {
                        cmbProducto.SelectedItem = selectedItem;
                    }
                    else
                    {
                        cmbProducto.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbProducto.SelectedIndex = -1;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener el proceso si los campos no son válidos
            }

            using (var conn = _conexion.GetConnection())
            {
                try
                {
                    _conexion.OpenConnection(conn);

                    // Comando para insertar la adquisición
                    SqlCommand cmdAdq = new SqlCommand("sp_InsertAdquisicion", conn);
                    cmdAdq.CommandType = CommandType.StoredProcedure;

                    cmdAdq.Parameters.AddWithValue("@nom_usu", usuario);
                    cmdAdq.Parameters.AddWithValue("@fec_adq", dtpFecha.Value);
                    cmdAdq.Parameters.AddWithValue("@prov_adq", txtProveedor.Text);
                    cmdAdq.Parameters.AddWithValue("@obs_adq", txtObservacion.Text);

                    // Ejecutar el procedimiento almacenado para insertar la adquisición y obtener su ID
                    var idAdq = Convert.ToInt32(cmdAdq.ExecuteScalar());

                    // Comando para insertar el detalle de adquisición
                    SqlCommand cmdDetalle = new SqlCommand("sp_InsertDetalleAdquisicion", conn);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_adq", idAdq);
                    cmdDetalle.Parameters.AddWithValue("@id_prod", ((dynamic)cmbProducto.SelectedItem).Value);
                    cmdDetalle.Parameters.AddWithValue("@cant_ent", txtCantidad.Text);

                    // Ejecutar el procedimiento almacenado para insertar el detalle
                    cmdDetalle.ExecuteNonQuery();

                    MessageBox.Show("Adquisición y su detalle guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clases.Bitacora bitacora = new Clases.Bitacora();
                    bitacora.Insertar("Se agregó una adquisición y su detalle con número " + idAdq, usuario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la adquisición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }

            LoadDetalleAdquisicion(); // Recargar las adquisiciones
            ClearFields(); // Limpiar los campos del formulario
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedAdqId == 0 || selectedDetAdqId == 0)
            {
                MessageBox.Show("Por favor, seleccione una adquisición para actualizar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos antes de proceder
            if (!ValidateFields())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = _conexion.GetConnection())
            {
                try
                {
                    _conexion.OpenConnection(conn);

                    // Comando para actualizar la adquisición
                    SqlCommand cmdUpdateAdq = new SqlCommand("sp_UpdateAdquisicion", conn);
                    cmdUpdateAdq.CommandType = CommandType.StoredProcedure;

                    // Asignar los parámetros para la adquisición
                    cmdUpdateAdq.Parameters.AddWithValue("@id_adq", selectedAdqId);
                    cmdUpdateAdq.Parameters.AddWithValue("@nom_usu", usuario);
                    cmdUpdateAdq.Parameters.AddWithValue("@fec_adq", dtpFecha.Value);
                    cmdUpdateAdq.Parameters.AddWithValue("@prov_adq", txtProveedor.Text);
                    cmdUpdateAdq.Parameters.AddWithValue("@obs_adq", txtObservacion.Text);

                    // Ejecutar el procedimiento almacenado para actualizar la adquisición
                    cmdUpdateAdq.ExecuteNonQuery();

                    // Comando para actualizar el detalle de adquisición
                    SqlCommand cmdUpdateDetalle = new SqlCommand("sp_UpdateDetalleAdquisicion", conn);
                    cmdUpdateDetalle.CommandType = CommandType.StoredProcedure;

                    // Asignar los parámetros para el detalle de adquisición
                    cmdUpdateDetalle.Parameters.AddWithValue("@id_det_adq", selectedDetAdqId);
                    cmdUpdateDetalle.Parameters.AddWithValue("@id_adq", selectedAdqId);
                    cmdUpdateDetalle.Parameters.AddWithValue("@id_prod", ((dynamic)cmbProducto.SelectedItem).Value);
                    cmdUpdateDetalle.Parameters.AddWithValue("@cant_ent", txtCantidad.Text);

                    // Ejecutar el procedimiento almacenado para actualizar el detalle
                    cmdUpdateDetalle.ExecuteNonQuery();

                    MessageBox.Show("Adquisición y su detalle actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clases.Bitacora bitacora = new Clases.Bitacora();
                    bitacora.Insertar("Se actualizó una adquisición y su detalle con número " + selectedAdqId + selectedDetAdqId, usuario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la adquisición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }

            // Recargar la tabla con los datos actualizados
            LoadDetalleAdquisicion();
            ClearFields(); // Limpiar los campos del formulario después de la actualización
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedAdqId == 0 || selectedDetAdqId == 0)
            {
                MessageBox.Show("Por favor, seleccione una adquisición para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preguntar al usuario si quiere eliminar toda la adquisición o solo el detalle
            var result = MessageBox.Show("¿Desea eliminar toda la adquisición y sus detalles, o solo el detalle seleccionado?",
                                         "Confirmar eliminación",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button3);

            using (var conn = _conexion.GetConnection())
            {
                try
                {
                    _conexion.OpenConnection(conn);

                    if (result == DialogResult.Yes)
                    {
                        // Eliminar toda la adquisición junto con sus detalles
                        SqlCommand cmdDeleteAdq = new SqlCommand("sp_DeleteAdquisicion", conn);
                        cmdDeleteAdq.CommandType = CommandType.StoredProcedure;
                        cmdDeleteAdq.Parameters.AddWithValue("@IdAdq", selectedAdqId);

                        cmdDeleteAdq.ExecuteNonQuery();
                        MessageBox.Show("Adquisición y todos sus detalles eliminados exitosamente.", "Eliminación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clases.Bitacora bitacora = new Clases.Bitacora();
                        bitacora.Insertar("Se eliminó una adquisición con número " + selectedAdqId, usuario);
                    }
                    else if (result == DialogResult.No)
                    {
                        // Eliminar solo el detalle de adquisición seleccionado
                        SqlCommand cmdDeleteDetalle = new SqlCommand("sp_DeleteDetalleAdquisicion", conn);
                        cmdDeleteDetalle.CommandType = CommandType.StoredProcedure;
                        cmdDeleteDetalle.Parameters.AddWithValue("@id_det_adq", selectedDetAdqId);

                        cmdDeleteDetalle.ExecuteNonQuery();
                        MessageBox.Show("Detalle de adquisición eliminado exitosamente.", "Eliminación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la adquisición o el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }

            // Recargar la tabla con los datos actualizados
            LoadDetalleAdquisicion();
            ClearFields(); // Limpiar los campos del formulario después de la eliminación
        }

        private void ClearFields()
        {
            // Restablecer los controles a sus valores por defecto
            dtpFecha.Value = DateTime.Now; // Establecer la fecha a la fecha actual
            txtProveedor.Clear(); // Limpiar el campo de texto del proveedor
            txtObservacion.Clear(); // Limpiar el campo de texto de observación
            txtCantidad.Clear(); // Limpiar el campo de texto de cantidad
            cmbProducto.SelectedIndex = -1; // Reiniciar la selección del combo de productos
        }

        private bool ValidateFields()
        {
            // Verificar si el campo de proveedor está vacío
            if (string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                MessageBox.Show("El proveedor es un campo obligatorio.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // No válido
            }

            // Verificar si el campo de fecha está vacío
            if (dtpFecha.Value == null || dtpFecha.Value < DateTime.Now.Date)
            {
                MessageBox.Show("Por favor, seleccione una fecha válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // No válido
            }

            // Verificar si el campo de cantidad está vacío o no es un número
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // No válido
            }

            // Verificar si un producto está seleccionado
            if (cmbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // No válido
            }

            return true; // Todos los campos son válidos
        }
    }
}
