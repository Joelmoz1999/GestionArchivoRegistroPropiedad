using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionArchivoRegistroPropiedad.Models;

public partial class GestionArchivoRegistroPropiedadContext : DbContext
{
    public GestionArchivoRegistroPropiedadContext()
    {
    }

    public GestionArchivoRegistroPropiedadContext(DbContextOptions<GestionArchivoRegistroPropiedadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Custodia> Custodias { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<TiposLibro> TiposLibros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.222\\SQLEXPRESS;Database=GestionArchivoRegistroPropiedad;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Custodia>(entity =>
        {
            entity.HasKey(e => e.CustodiaId).HasName("PK__Custodia__437DDB6FF258A4F7");

            entity.Property(e => e.CustodiaId).HasColumnName("CustodiaID");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaEntrega)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FuncionarioId).HasColumnName("FuncionarioID");
            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.ObservacionesDevolucion).HasMaxLength(255);
            entity.Property(e => e.ObservacionesEntrega).HasMaxLength(255);
            entity.Property(e => e.UsuarioRegistraId).HasColumnName("UsuarioRegistraID");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.Custodia)
                .HasForeignKey(d => d.FuncionarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Custodia_Funcionario");

            entity.HasOne(d => d.Libro).WithMany(p => p.Custodia)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Custodia_Libro");

            entity.HasOne(d => d.UsuarioRegistra).WithMany(p => p.Custodia)
                .HasForeignKey(d => d.UsuarioRegistraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Custodia_Usuario");
        });







        modelBuilder.Entity<TiposLibro>(entity =>
        {
            entity.HasKey(e => e.TipoLibroId).HasName("PK__TiposLib__XXXXXXXXXXXX");
            entity.HasIndex(e => e.Nombre, "UQ__TiposLib__Nombre").IsUnique();
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
        });






        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.FuncionarioId).HasName("PK__Funciona__297ECD4AB2917FEA");

            entity.HasIndex(e => e.Cedula, "UQ__Funciona__B4ADFE38E44A07F6").IsUnique();

            entity.Property(e => e.FuncionarioId).HasColumnName("FuncionarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombres).HasMaxLength(100);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libros__35A1EC8D3264A287");

            entity.HasIndex(e => new { e.TipoLibro, e.Anio, e.Tomo }, "UQ_Libro_Unico").IsUnique();

            entity.HasIndex(e => e.CodigoBarras, "UQ__Libros__F61589C829127545").IsUnique();

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.CodigoBarras).HasMaxLength(50);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Disponible");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(500);
            entity.Property(e => e.TipoLibro).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposLibro>(entity =>
        {
            entity.HasKey(e => e.TipoLibroId).HasName("PK__TiposLib__D5FDC1D5E2E5AEFA");

            entity.HasIndex(e => e.Nombre, "UQ__TiposLib__75E3EFCF36E6DF3E").IsUnique();

            entity.Property(e => e.TipoLibroId).HasColumnName("TipoLibroID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7983B745CB0");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE0159B7E79").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ContrasenaHash).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
