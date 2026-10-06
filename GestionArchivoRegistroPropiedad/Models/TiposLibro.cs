using System;
using System.Collections.Generic;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class TiposLibro
{
    public int TipoLibroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
