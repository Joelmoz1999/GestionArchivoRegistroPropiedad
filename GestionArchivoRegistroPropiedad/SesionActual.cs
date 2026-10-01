using GestionArchivoRegistroPropiedad.Models;

namespace GestionArchivoRegistroPropiedad
{
    /// <summary>
    /// Clase estática que guarda la información del usuario que está logueado.
    /// Se usa en todo el sistema para saber quién está trabajando.
    /// </summary>
    public static partial class SesionActual
    {
        public static Usuario? UsuarioLogueado { get; set; }

        public static bool EsAdministrador => UsuarioLogueado?.Rol == "Administrador";
        public static bool EsEncargadoArchivo => UsuarioLogueado?.Rol == "EncargadoArchivo";

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
    }
}