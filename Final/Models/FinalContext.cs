using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class FinalContext : DbContext
{
    public FinalContext()
    {
    }

    public FinalContext(DbContextOptions<FinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    

      

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.EquipoId).HasName("PK__Equipos__DE8A0BFFB0414E07");

            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaAdquisicion).HasColumnType("datetime");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C02480531156AB3");

            entity.HasIndex(e => e.NumeroFactura, "UQ__Facturas__CF12F9A6EEFEE094").IsUnique();

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.PagoId).HasColumnName("PagoID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Pago).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PagoId)
                .HasConstraintName("FK__Facturas__PagoID__571DF1D5");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pagos__F00B6158CE3392C6");

            entity.Property(e => e.PagoId).HasColumnName("PagoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("FK__Pagos__ReservaID__534D60F1");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservas__C3993703B63DC4D5");

            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");
            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaReserva).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.EquipoId)
                .HasConstraintName("FK__Reservas__Equipo__5070F446");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Reservas__Usuari__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798D51B3A97");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105346C99F6F1").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(50);
            entity.Property(e => e.TipoUsuario).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
