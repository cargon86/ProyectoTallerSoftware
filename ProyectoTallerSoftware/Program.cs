using ProyectoTallerSoftware.Modulos.Clases;
using ProyectoTallerSoftware.Modulos.Bitacora;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTallerSoftware.Modulos.Productos;
using ProyectoTallerSoftware.Modulos.Inventario;
using ProyectoTallerSoftware.Modulos;
using ProyectoTallerSoftware.Modulos.Home;
using ProyectoTallerSoftware.Modulos.Empleados;
using ProyectoTallerSoftware.Modulos.Hoja_Requisicion;
using ProyectoTallerSoftware.Modulos.Adquisicion;

namespace ProyectoTallerSoftware
{
     class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());

            // Crear una instancia de la clase Conexion
            Conexion conexion = new Conexion();

            // Intentar obtener la conexión
            SqlConnection con = conexion.GetConnection();

            // Verificar si la conexión fue obtenida
            if (con != null)
            {
                // Abrir la conexión
                conexion.OpenConnection(con);

                // Aquí podrías realizar alguna operación adicional, como ejecutar consultas

                // Cerrar la conexión
                conexion.CloseConnection(con);
            }
            else
            {
                Console.WriteLine("No se pudo establecer la conexión.");
            }

            // Mantener la consola abierta
            Console.ReadLine();
        }
    }
}
