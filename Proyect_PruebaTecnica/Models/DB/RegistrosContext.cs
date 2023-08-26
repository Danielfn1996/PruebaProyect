using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyect_PruebaTecnica.Models.DB;

public partial class RegistrosContext : DbContext
{
    public RegistrosContext()
    {
    }

    public RegistrosContext(DbContextOptions<RegistrosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactoPersona> ContactoPersonas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactoPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contacto__3213E83F0C0C8D61");

            entity.ToTable("contactoPersona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico1)
                .HasMaxLength(50)
                .HasColumnName("correoElectronico1");
            entity.Property(e => e.CorreoElectronico2)
                .HasMaxLength(50)
                .HasColumnName("correoElectronico2");
            entity.Property(e => e.DireccionResidencia1)
                .HasMaxLength(50)
                .HasColumnName("direccionResidencia1");
            entity.Property(e => e.DireccionResidencia2)
                .HasMaxLength(50)
                .HasColumnName("direccionResidencia2");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.NumeroTelefono1)
                .HasMaxLength(10)
                .HasColumnName("numeroTelefono1");
            entity.Property(e => e.NumeroTelefono2)
                .HasMaxLength(10)
                .HasColumnName("numeroTelefono2");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.ContactoPersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_PERSONA");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persona__3213E83FB8248DDB");

            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
			entity.Property(e => e.NumDocumento)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("NumDocumento");

		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
