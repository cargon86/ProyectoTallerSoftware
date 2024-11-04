using ProyectoTallerSoftware.Modulos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos
{
    public partial class Login : Form
    {
        private readonly Conexion _conexion;

        public Login()
        {
            InitializeComponent();
            _conexion = new Conexion();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtb_nom_usu.Text = "Ingrese su nombre de usuario";
            txtb_nom_usu.ForeColor = System.Drawing.Color.Gray;
            txtb_pass_usu.Text = "Ingrese su contraseña";
            txtb_pass_usu.ForeColor = System.Drawing.Color.Gray;
        }

        private void txtb_nom_usu_Enter(object sender, EventArgs e)
        {
            if (txtb_nom_usu.Text == "Ingrese su nombre de usuario")
            {
                txtb_nom_usu.Text = "";
                txtb_nom_usu.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtb_nom_usu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_nom_usu.Text))
            {
                txtb_nom_usu.Text = "Ingrese su nombre de usuario";
                txtb_nom_usu.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtb_pass_usu_Enter(object sender, EventArgs e)
        {
            if (txtb_pass_usu.Text == "Ingrese su contraseña")
            {
                txtb_pass_usu.Text = "";
                txtb_pass_usu.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtb_pass_usu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_pass_usu.Text))
            {
                txtb_pass_usu.Text = "Ingrese su contraseña";
                txtb_pass_usu.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            string username = txtb_nom_usu.Text;
            string password = txtb_pass_usu.Text;

            string hashedPassword = CrearHashContraseña(password);

            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_VerifyLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom_usu", username);
                cmd.Parameters.AddWithValue("@con_usu", hashedPassword);

                try
                {
                    _conexion.OpenConnection(conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home.Home usuariosForm = new Home.Home();
                        usuariosForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar las credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtb_nom_usu.Text) || txtb_nom_usu.Text == "Ingrese su nombre de usuario")
            {
                MessageBox.Show("Por favor, ingresa el nombre de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtb_pass_usu.Text) || txtb_pass_usu.Text == "Ingrese su contraseña")
            {
                MessageBox.Show("Por favor, ingresa la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
