using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Usuarios
{
    public partial class UsuarioControl : UserControl
    {
        private readonly Conexion _conexion;
        private string usuario = "";

        public UsuarioControl(string usuario)
        {
            InitializeComponent();
            _conexion = new Conexion();
            this.usuario = usuario;
        }

        private void UsuarioControl_Load(object sender, EventArgs e)
        {
            cmb_rol_usu.Items.Add(new { Text = "Administrador", Value = 1 });
            cmb_rol_usu.Items.Add(new { Text = "Empleado", Value = 0 });
            cmb_rol_usu.DisplayMember = "Text";
            cmb_rol_usu.ValueMember = "Value";
            LeerUsuarios();
        }

        private void LeerUsuarios()
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    _conexion.OpenConnection(conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv_usuarios.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                EjecutarOperacionDB("sp_CrearUsuario", cmd =>
                {
                    cmd.Parameters.AddWithValue("@nom_usu", txtb_nom_usu.Text); 
                    string hashCon = CrearHashContraseña(txtb_pass_usu.Text);
                    cmd.Parameters.AddWithValue("@con_usu", hashCon);
                    cmd.Parameters.AddWithValue("@rol_usu", ((dynamic)cmb_rol_usu.SelectedItem).Value);
                    cmd.Parameters.AddWithValue("@est_usu", 1);
                }, "Usuario guardado exitosamente.", "Se creó un nuevo usuario con nombre ");
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(esActualizacion: true))
            {
                EjecutarOperacionDB("sp_UpdateUser", cmd =>
                {
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
                }, "Usuario actualizado exitosamente.", "Se actualizó un usuario con nombre ");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea borrar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EjecutarOperacionDB("sp_DeleteUser", cmd =>
                {
                    cmd.Parameters.AddWithValue("@nom_usu", txtb_nom_usu.Text);
                }, "Usuario eliminado exitosamente.", "Se desactivó un usuario con nombre ");
            }
        }

        private void dgv_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_usuarios.CurrentRow != null)
            {
                txtb_nom_usu.Text = dgv_usuarios.CurrentRow.Cells["Nombre de Usuario"].Value?.ToString();
                txtb_pass_usu.Text = "";
                txtb_passc_usu.Text = "";
                var rolText = dgv_usuarios.CurrentRow.Cells["Rol"].Value?.ToString();
                cmb_rol_usu.SelectedItem = cmb_rol_usu.Items.Cast<dynamic>().FirstOrDefault(item => item.Text == rolText);
            }
        }

        private void dgv_usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_usuarios.CurrentRow != null)
            {
                txtb_nom_usu.Text = dgv_usuarios.CurrentRow.Cells["Nombre de Usuario"].Value?.ToString();
                txtb_pass_usu.Text = "";
                txtb_passc_usu.Text = "";
                var rolText = dgv_usuarios.CurrentRow.Cells["Rol"].Value?.ToString();
                cmb_rol_usu.SelectedItem = cmb_rol_usu.Items.Cast<dynamic>().FirstOrDefault(item => item.Text == rolText);
            }
        }

        private bool ValidarCampos(bool esActualizacion = false)
        {
            if (!ValidarDatosBasicos())
                return false;

            if (!esActualizacion && !ValidarUsuarioNuevo())
                return false;

            if (!ValidarContraseña(esActualizacion))
                return false;

            return ValidarRol();
        }

        private bool ValidarDatosBasicos()
        {
            if (string.IsNullOrWhiteSpace(txtb_nom_usu.Text))
            {
                MostrarError("Por favor, ingresa el nombre de usuario.");
                return false;
            }

            if (txtb_nom_usu.Text.Length < 3 || txtb_nom_usu.Text.Length > 20)
            {
                MostrarError("El nombre de usuario debe tener entre 3 y 20 caracteres.");
                return false;
            }

            var caracteresEspecialesPermitidos = new[] { '!', '¡', '-', '_' };
            var soloCaracteresPermitidos = txtb_nom_usu.Text.All(c => 
                char.IsLetterOrDigit(c) || caracteresEspecialesPermitidos.Contains(c));

            if (!soloCaracteresPermitidos)
            {
                MostrarError("El nombre de usuario solo puede contener letras, números y los caracteres especiales: !, ¡, -, _");
                return false;
            }

            return true;
        }

        private bool ValidarUsuarioNuevo()
        {
            if (UsuarioExiste(txtb_nom_usu.Text))
            {
                MostrarError("Este nombre de usuario ya existe.");
                return false;
            }
            return true;
        }

        private bool ValidarContraseña(bool esActualizacion)
        {
            if (esActualizacion && string.IsNullOrWhiteSpace(txtb_pass_usu.Text))
                return true;

            if (!esActualizacion && string.IsNullOrWhiteSpace(txtb_pass_usu.Text))
            {
                MostrarError("Por favor, ingresa la contraseña.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtb_pass_usu.Text))
            {
                if (!ValidarComplejidadContraseña())
                    return false;

                if (!ValidarConfirmacionContraseña())
                    return false;
            }

            return true;
        }

        private bool ValidarComplejidadContraseña()
        {
            if (txtb_pass_usu.Text.Length < 8 || txtb_pass_usu.Text.Length > 20)
            {
                MostrarError("La contraseña debe tener entre 8 y 20 caracteres.");
                return false;
            }

            var tieneMayuscula = txtb_pass_usu.Text.Any(char.IsUpper);
            var tieneMinuscula = txtb_pass_usu.Text.Any(char.IsLower);
            var tieneNumero = txtb_pass_usu.Text.Any(char.IsDigit);
            var caracteresEspecialesPermitidos = new[] { '!', '¡', '-', '_' };
            var tieneCaracterEspecial = txtb_pass_usu.Text.Any(c => caracteresEspecialesPermitidos.Contains(c));
            var soloCaracteresPermitidos = txtb_pass_usu.Text.All(c => 
                char.IsLetterOrDigit(c) || caracteresEspecialesPermitidos.Contains(c));

            if (!soloCaracteresPermitidos)
            {
                MostrarError("La contraseña solo puede contener letras, números y los caracteres especiales: !, ¡, -, _");
                return false;
            }

            if (!tieneMayuscula || !tieneMinuscula || !tieneNumero || !tieneCaracterEspecial)
            {
                MostrarError("La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial (!, ¡, -, _).");
                return false;
            }
            return true;
        }

        private bool ValidarConfirmacionContraseña()
        {
            if (string.IsNullOrWhiteSpace(txtb_passc_usu.Text))
            {
                MostrarError("Por favor, ingresa la confirmación de la contraseña.");
                return false;
            }

            if (txtb_passc_usu.Text != txtb_pass_usu.Text)
            {
                MostrarError("La contraseña y la confirmación no coinciden.");
                return false;
            }
            return true;
        }

        private bool ValidarRol()
        {
            if (cmb_rol_usu.SelectedItem == null)
            {
                MostrarError("Por favor, selecciona el rol.");
                return false;
            }
            return true;
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EjecutarOperacionDB(string nombreProcedimiento, Action<SqlCommand> configurarParametros, string mensajeExito, string accionBitacora)
        {
            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                configurarParametros(cmd);

                try
                {   
                    _conexion.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    var bitacora = new Clases.Bitacora();
                    bitacora.Insertar(accionBitacora + txtb_nom_usu.Text, usuario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
            LeerUsuarios();
            LimpiarCampos();
        }

        private bool UsuarioExiste(string nombreUsuario)
        {
            try
            {
                using (var conn = _conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_GetUsers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_usu", nombreUsuario);

                    _conexion.OpenConnection(conn);
                    var existe = (int)cmd.ExecuteScalar();
                    return existe > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void LimpiarCampos()
        {
            txtb_nom_usu.Clear();
            txtb_passc_usu.Clear();
            txtb_pass_usu.Clear();
            cmb_rol_usu.SelectedIndex = -1;
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
    }
}
