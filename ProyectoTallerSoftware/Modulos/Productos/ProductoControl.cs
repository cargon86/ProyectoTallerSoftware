﻿using ProyectoTallerSoftware.Modulos.Clases;
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
    public partial class ProductoControl : UserControl
    {
        private readonly Conexion _conexion;
        private string usuario = "";

        public ProductoControl(string usuario)
        {
            InitializeComponent();
            _conexion = new Conexion();
            this.usuario = usuario;
        }

        private void ProductoControl_Load(object sender, EventArgs e)
        {
            LoadMeasures();
            LoadProducts();
        }

        private void LoadMeasures()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetMeasures", conn); 
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbMedida.Items.Clear(); 
                while (reader.Read())
                {
                    cmbMedida.Items.Add(new
                    {
                        Text = reader["nom_med"].ToString(), 
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

                
                dgvProductos.Columns["id_prod"].Visible = false; 
                _conexion.CloseConnection(conn);
            }
        }

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


        private void ClearFields()
        {
            txtProducto.Clear();
            txtDescripcion.Clear();
            cmbMedida.SelectedIndex = -1; 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidateFields())
            {
                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_AddProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@NomProd", txtProducto.Text);
                    cmd.Parameters.AddWithValue("@DesProd", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@IdMed", ((dynamic)cmbMedida.SelectedItem).Value);

                    try
                    {
                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clases.Bitacora bitacora = new Clases.Bitacora();
                        bitacora.Insertar("Se creó un nuevo producto con nombre " + txtProducto.Text, usuario);
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
                LoadProducts(); 
                ClearFields(); 
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un producto para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFields())
                {
                    MessageBox.Show("Por favor, completa todos los campos requeridos antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvProductos.CurrentRow.Cells["id_prod"].Value;

                using (var conn = _conexion.GetConnection())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@IdProd", selectedId);
                        cmd.Parameters.AddWithValue("@NomProd", txtProducto.Text);
                        cmd.Parameters.AddWithValue("@DesProd", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@IdMed", ((dynamic)cmbMedida.SelectedItem).Value);


                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();


                        Clases.Bitacora bitacora = new Clases.Bitacora();
                        bitacora.Insertar("Se actualizó un producto con nombre " + txtProducto.Text, usuario);

                        MessageBox.Show("El producto se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Hubo un error al intentar actualizar el producto. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _conexion.CloseConnection(conn);
                    }
                }

                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este producto? Esta acción no se puede deshacer.",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );


                if (result != DialogResult.Yes)
                {
                    MessageBox.Show("Eliminación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedId = (int)dgvProductos.CurrentRow.Cells["id_prod"].Value;

                using (var conn = _conexion.GetConnection())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdProd", selectedId);

                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();

                        Clases.Bitacora bitacora = new Clases.Bitacora();
                        bitacora.Insertar("Se eliminó un producto con ID " + selectedId, usuario);

                        MessageBox.Show("El producto se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Hubo un error al intentar eliminar el producto. Detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _conexion.CloseConnection(conn);
                    }
                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
               
                txtProducto.Text = dgvProductos.CurrentRow.Cells["nom_prod"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["des_prod"].Value.ToString();

            
                var selectedIdMed = dgvProductos.CurrentRow.Cells["id_med"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedIdMed))
                {
                    cmbMedida.SelectedItem = cmbMedida.Items.Cast<dynamic>().FirstOrDefault(item => item.Value == selectedIdMed);
                }
                else
                {
                    cmbMedida.SelectedIndex = -1; 
                }
            }
        }
    }
}
