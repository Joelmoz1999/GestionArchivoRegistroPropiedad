using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestionArchivoRegistroPropiedad
{
    public static class TiposLibrosHelper
    {
        /// <summary>
        /// Obtiene la lista de tipos de libros activos desde la base de datos.
        /// Si no hay ninguno, devuelve la lista por defecto.
        /// </summary>
        public static List<string> ObtenerTiposActivos(GestionArchivoRegistroPropiedadContext context)
        {
            try
            {
                context.ChangeTracker.Clear();

                var tipos = context.TiposLibros
                    .AsNoTracking()
                    .Where(t => t.Activo == true)
                    .OrderBy(t => t.Nombre)
                    .Select(t => t.Nombre)
                    .ToList();

                if (tipos.Count == 0)
                {
                    return new List<string>
                    {
                        "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros"
                    };
                }

                return tipos;
            }
            catch
            {
                return new List<string>
                {
                    "Propiedad", "Sentencias", "Protocolos", "Poderes", "Hipotecas", "Otros"
                };
            }
        }
    }
}