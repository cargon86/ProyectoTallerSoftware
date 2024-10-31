using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ProyectoTallerSoftware.Modulos.Usuarios
{
    public partial class Usuarios : Form
    {
        private readonly Conexion _conexion;

        public Usuarios()
        {
            InitializeComponent();
            _conexion = new Conexion();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cmb_rol_usu.Items.Add(new { Text = "Administrador", Value = 0 });
            cmb_rol_usu.Items.Add(new { Text = "Empleado", Value = 1 });
            cmb_rol_usu.DisplayMember = "Text";
            cmb_rol_usu.ValueMember = "Value";
            cmb_sta_usu.Items.Add(new { Text = "Inactivo", Value = 0 });
            cmb_sta_usu.Items.Add(new { Text = "Activo", Value = 1 });
            cmb_sta_usu.DisplayMember = "Text";
            cmb_sta_usu.ValueMember = "Value";
            LeerUsuarios();
        }

        private void LeerUsuarios()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _conexion.OpenConnection(conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_usuarios.DataSource = dt;
                _conexion.CloseConnection(conn);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_CrearUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nom_usu", txtb_nom_usu.Text);
                    string hashCon = CrearHashContraseña(txtb_pass_usu.Text);
                    cmd.Parameters.AddWithValue("@con_usu", hashCon);
                    cmd.Parameters.AddWithValue("@rol_usu", ((dynamic)cmb_rol_usu.SelectedItem).Value);
                    cmd.Parameters.AddWithValue("@est_usu", ((dynamic)cmb_sta_usu.SelectedItem).Value);

                    try
                    {
                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _conexion.CloseConnection(conn);
                    }
                }
                LeerUsuarios();
                LimpiarCampos();
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_usuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un usuario para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCampos(esActualizacion: true))
            {
                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
             
                    cmd.Parameters.AddWithValue("@nom_usu", txtb_nom_usu.Text);
                    if (!string.IsNullOrWhiteSpace(txtb_pass_usu.Text))
                    {
                        string hashCon = CrearHashContraseña(txtb_pass_usu.Text);
                        cmd.Parameters.AddWithValue("@con_usu", hashCon);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@con_usu", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@rol_usu", ((dynamic)cmb_rol_usu.SelectedItem).Value);
                    cmd.Parameters.AddWithValue("@est_usu", ((dynamic)cmb_sta_usu.SelectedItem).Value);

                    try
                    {
                        _conexion.OpenConnection(conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _conexion.CloseConnection(conn);
                    }
                }
                LeerUsuarios();
                LimpiarCampos();
            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_usuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom_usu", txtb_nom_usu.Text);

                try
                {
                    _conexion.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
            LeerUsuarios();
        }

        private void dgv_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_usuarios.CurrentRow != null)
            {
                txtb_nom_usu.Text = dgv_usuarios.CurrentRow.Cells["Nombre de Usuario"].Value?.ToString();
                txtb_pass_usu.Text = "";
                var rolText = dgv_usuarios.CurrentRow.Cells["Rol"].Value?.ToString();
                cmb_rol_usu.SelectedItem = cmb_rol_usu.Items.Cast<dynamic>().FirstOrDefault(item => item.Text == rolText);

                var estadoText = dgv_usuarios.CurrentRow.Cells["Estado"].Value?.ToString();
                cmb_sta_usu.SelectedItem = cmb_sta_usu.Items.Cast<dynamic>().FirstOrDefault(item => item.Text == estadoText);
            }
        }

        private bool ValidarCampos(bool esActualizacion = false)
        {
            if (string.IsNullOrWhiteSpace(txtb_nom_usu.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!esActualizacion)
            {
                if (string.IsNullOrWhiteSpace(txtb_pass_usu.Text))
                {
                    MessageBox.Show("Por favor, ingresa la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtb_passc_usu.Text))
                {
                    MessageBox.Show("Por favor, ingresa la confirmación de la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (cmb_rol_usu.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona el rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (cmb_sta_usu.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione el estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtb_nom_usu.Clear();
            txtb_passc_usu.Clear();
            txtb_pass_usu.Clear();
            cmb_rol_usu.SelectedIndex = -1;
            cmb_sta_usu.SelectedIndex = -1;
        }

        public string CrearHashContraseña(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            Usuarios UsuariosForm = new Usuarios();
            UsuariosForm.Show();
            this.Hide();
        }

        private void btnRequisiciones_Click_1(object sender, EventArgs e)
        {
            Hoja_Requisicion.Hoja_Requisicion requisicionform = new Hoja_Requisicion.Hoja_Requisicion();
            requisicionform.Show();
            this.Hide();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            Productos.Productos productoform = new Productos.Productos();
            productoform.Show();
            this.Hide();
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            Reportes.Reportes ReportesForm = new Reportes.Reportes();
            ReportesForm.Show();
            this.Hide();
        }

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            Empleados.Empleados EmpleadosForm = new Empleados.Empleados();
            EmpleadosForm.Show();
            this.Hide();
        }

        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            Inventario.Inventario InventarioForm = new Inventario.Inventario();
            InventarioForm.Show();
            this.Hide();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }
    }
}
