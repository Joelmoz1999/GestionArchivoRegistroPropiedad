using System;
using System.Collections.Generic;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class Custodia
{
    public int CustodiaId { get; set; }

    public int LibroId { get; set; }

    public int FuncionarioId { get; set; }

    public int UsuarioRegistraId { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string? ObservacionesEntrega { get; set; }

    public string? ObservacionesDevolucion { get; set; }

    public virtual Funcionario Funcionario { get; set; } = null!;

    public virtual Libro Libro { get; set; } = null!;

    public virtual Usuario UsuarioRegistra { get; set; } = null!;
}
