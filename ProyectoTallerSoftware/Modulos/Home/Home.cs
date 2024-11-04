using System;
using System.Windows.Forms;

namespace ProyectoTallerSoftware.Modulos.Home
{
    public partial class Home : Form
    {
        public Home(string user)
        {
            InitializeComponent();
            lbl_nom_usu.Text = user;
        }

        public void CambiarFormulario(UserControl control)
        {
            pnl_contenido.Controls.Clear();
            pnl_contenido.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CambiarFormulario(new Usuarios.UsuarioControl());
            lbl_form.Text = "Usuarios";
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
