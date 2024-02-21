using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reserva_1.Models;

public partial class ReservacionContext : DbContext
{
    public ReservacionContext()
    {
    }

    public ReservacionContext(DbContextOptions<ReservacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Reservacion;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.ToTable("Habitacion");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroHabitacion)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TipoHabitacion).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.TipoHabitacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Habitacion_TipoHabitacion");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.ToTable("Reservacion");

            entity.Property(e => e.ApellidosCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DpiCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.NombresCliente)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Habitacion).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.HabitacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservacion_Habitacion");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.TipoHabitacionId).HasName("PK_Table_1");

            entity.ToTable("TipoHabitacion");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
