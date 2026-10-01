using System;
using System.Collections.Generic;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class Funcionario
{
    public int FuncionarioId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Cedula { get; set; }

    public string? Cargo { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Custodia> Custodia { get; set; } = new List<Custodia>();
}
