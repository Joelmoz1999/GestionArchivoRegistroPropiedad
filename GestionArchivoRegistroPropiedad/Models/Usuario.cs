using System;
using System.Collections.Generic;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Custodia> Custodia { get; set; } = new List<Custodia>();
}
