using System;
using System.Collections.Generic;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string TipoLibro { get; set; } = null!;

    public int Anio { get; set; }

    public int Tomo { get; set; }

    public int PartidaInicial { get; set; }

    public int PartidaFinal { get; set; }

    public string? Observacion { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public string? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Custodia> Custodia { get; set; } = new List<Custodia>();
}
