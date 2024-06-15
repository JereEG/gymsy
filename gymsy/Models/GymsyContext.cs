using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gymsy.Models;

public partial class GymsyContext : DbContext
{
    public GymsyContext()
    {
    }

    public GymsyContext(DbContextOptions<GymsyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlumnoSuscripcion> AlumnoSuscripcions { get; set; }

    public virtual DbSet<EstadoFisico> EstadoFisicos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PlanEntrenamiento> PlanEntrenamientos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDePago> TipoDePagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JEREDELL;Database=gymsy;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlumnoSuscripcion>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoSuscripcion).HasName("ALUMNOSUSCRIPCION_PK_ID_ALUMNO_SUSCRIPCION");

            entity.ToTable("AlumnoSuscripcion");

            entity.Property(e => e.IdAlumnoSuscripcion).HasColumnName("id_alumno_suscripcion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("date")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.IdPlanEntrenamiento).HasColumnName("id_plan_entrenamiento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdPlanEntrenamientoNavigation).WithMany(p => p.AlumnoSuscripcions)
                .HasForeignKey(d => d.IdPlanEntrenamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ALUMNOSUSCRIPCION_FK_AlumnoSuscripcion_PlanEntrenamiento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AlumnoSuscripcions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ALUMNOSUSCRIPCION_FK_AlumnoSuscripcion_Usuario");
        });

        modelBuilder.Entity<EstadoFisico>(entity =>
        {
            entity.HasKey(e => e.IdEstadoFisico).HasName("ESTADOFISICO_PK_ID_ESTADO_FISICO");

            entity.ToTable("EstadoFisico");

            entity.Property(e => e.IdEstadoFisico).HasColumnName("id_estado_fisico");
            entity.Property(e => e.Altura)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("altura");
            entity.Property(e => e.EstadoFisicoInactivo).HasColumnName("estado_fisico_inactivo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdAlumnoSuscripcion).HasColumnName("id_alumno_suscripcion");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Notas)
                .HasColumnType("text")
                .HasColumnName("notas");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdAlumnoSuscripcionNavigation).WithMany(p => p.EstadoFisicos)
                .HasForeignKey(d => d.IdAlumnoSuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ESTADOFISICO_FK_EstadoFisico_AlumnoSuscripcion");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PAGO_PK_ID_PAGO");

            entity.ToTable("Pago");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.CbuDestino)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("cbu_destino");
            entity.Property(e => e.CbuOrigen)
                .HasMaxLength(22)
                .IsUnicode(false)
                .HasColumnName("cbu_origen");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipo_pago");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.InactivoPago).HasColumnName("inactivo_pago");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PAGO_FK_PAGO_TIPOPAGO");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PAGO_FK_PAGO_USUARIO");
        });

        modelBuilder.Entity<PlanEntrenamiento>(entity =>
        {
            entity.HasKey(e => e.IdPlanEntrenamiento).HasName("PLANENTRENAMIENTO_PK_ID_PLAN_ENTRENAMIENTO");

            entity.ToTable("PlanEntrenamiento");

            entity.Property(e => e.IdPlanEntrenamiento).HasColumnName("id_plan_entrenamiento");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.PlanEntrenamientoInactivo).HasColumnName("plan_entrenamiento_inactivo");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PlanEntrenamientos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PLANENTRENAMIENTO_INSTRUCTOR");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("ROL_PK_ID_ROL");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RolInactivo).HasColumnName("rol_inactivo");
        });

        modelBuilder.Entity<TipoDePago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("TIPODEPAGO_PK_ID_TIPO_PAGO");

            entity.ToTable("TipoDePago");

            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipo_pago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoPagoInactivo).HasColumnName("tipo_pago_inactivo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("USUARIO_PK_ID_USUARIO");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Apodo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apodo");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("avatar_url");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numero_telefono");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.UsuarioInactivo).HasColumnName("usuario_inactivo");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("USUARIO_FK_USUARIO_ROL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
