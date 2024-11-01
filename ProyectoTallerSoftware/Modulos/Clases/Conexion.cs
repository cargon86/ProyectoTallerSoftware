﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoTallerSoftware.Modulos.Clases
{
    public class Conexion
    {
        // Cadena de conexión a la base de datos
        private string connectionString = @"Server=\SQLEXPRESS;Database=Sis_Inventario;Trusted_Connection=True;";

        // Método para obtener la conexión
        public SqlConnection GetConnection()
        {
            try
            {
                // Crear una nueva conexión SQL con la cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }


        // Método para abrir la conexión
        public void OpenConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}

