using System;

namespace ProyectoTallerSoftware.Modulos.Clases
{
    public static class Session
    {
        public static string CurrentUser { get; set; }

        // Método para verificar si el usuario está logueado
        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(CurrentUser);
        }
    }
}
