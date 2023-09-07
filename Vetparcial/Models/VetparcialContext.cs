using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vetparcial.Models;

public partial class VetparcialContext : DbContext
{
    public VetparcialContext()
    {
    }

    public VetparcialContext(DbContextOptions<VetparcialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alimento> Alimentos { get; set; }

    public virtual DbSet<Dueno> Duenos { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AEBB186\\SQLEXPRESS; Database=vetparcial; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alimento>(entity =>
        {
            entity.ToTable("alimento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Dueno>(entity =>
        {
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.ToTable("mascotas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Edad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("edad");
            entity.Property(e => e.IdAlim).HasColumnName("id_alim");
            entity.Property(e => e.IdDueno).HasColumnName("id_dueno");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoAnim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_anim");

            entity.HasOne(d => d.IdAlimNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdAlim)
                .HasConstraintName("FK_mascotas_alimento");

            entity.HasOne(d => d.IdDuenoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdDueno)
                .HasConstraintName("FK_mascotas_Duenos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
