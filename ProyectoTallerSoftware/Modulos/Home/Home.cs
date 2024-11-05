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

namespace ProyectoTallerSoftware.Modulos.Home
{
    public partial class Home : Form
    {
        private readonly Conexion _conexion;
        private string usuario;
        public Home(string usuario)
        {
            InitializeComponent();
            _conexion = new Conexion();
            this.usuario = usuario;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            string rol = ObtenerRolUsuario(usuario);
            switch (rol)
            {
                case "1":
                    btnUsuarios.Enabled = true;
                    btnRequisiciones.Enabled = true;
                    btnProductos.Enabled = true;
                    btnReportes.Enabled = true;
                    btnAdquisicion.Enabled = true;
                    btnEmpleados.Enabled = true;
                    btnInventario.Enabled = true;
                    btn_bitacora.Enabled = true;
                    break;
                case "0":
                    btnUsuarios.Enabled = false;
                    btnRequisiciones.Enabled = true;
                    btnProductos.Enabled = true;
                    btnReportes.Enabled = true;
                    btnAdquisicion.Enabled = false;
                    btnEmpleados.Enabled = false;
                    btnInventario.Enabled = true;
                    btn_bitacora.Enabled = false;
                    break;
            }
        }

        private string ObtenerRolUsuario(string usuario)
        {
            string rol = "";

            using (var conn = _conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetRolUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nom_usu", usuario);

                try
                {
                    _conexion.OpenConnection(conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int valorRol = reader["rol_usu"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(reader["rol_usu"]);
                        rol = valorRol == 1 ? "1" : "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el rol del usuario: " + ex.Message);
                }
                finally
                {
                    _conexion.CloseConnection(conn);
                }
            }
            return rol;
        }

        public void CambiarFormulario(UserControl control)
        {
            pnl_contenedor.Controls.Clear();
            pnl_contenedor.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
       
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Usuarios.UsuarioControl(usuario));
            lbl_formulario.Text = "Usuarios";
        }

        private void btnRequisiciones_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Hoja_Requisicion.RequisicionControl(usuario));
            lbl_formulario.Text = "Requisición";
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Productos.ProductoControl(usuario));
            lbl_formulario.Text = "Productos";
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Reportes.ReporteControl());
            lbl_formulario.Text = "Reportes";
        }

        private void btnAdquisicion_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Adquisicion.AdquisicionControl(usuario));
            lbl_formulario.Text = "Adquisición";
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Empleados.EmpleadoControl(usuario));
            lbl_formulario.Text = "Empleados";
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Inventario.InventarioControl());
            lbl_formulario.Text = "Inventario";
        }

        private void btn_bitacora_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Bitacora.BitacoraControl());
            lbl_formulario.Text = "Bitacora";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }
    }
}
