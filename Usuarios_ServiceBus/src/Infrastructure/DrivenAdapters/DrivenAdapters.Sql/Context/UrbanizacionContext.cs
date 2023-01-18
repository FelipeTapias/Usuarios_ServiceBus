using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrivenAdapters.Sql.Context;

public partial class UrbanizacionContext : DbContext
{
    public UrbanizacionContext()
    {
    }

    public UrbanizacionContext(DbContextOptions<UrbanizacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apartamento> Apartamentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartame__3214EC07152AC73E");

            entity.Property(e => e.Ciudad).IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC078CE7E8C8");

            entity.Property(e => e.IdApartamento).HasColumnName("Id_Apartamento");
            entity.Property(e => e.Nombre).IsUnicode(false);

            entity.HasOne(d => d.IdApartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdApartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Id_Apartamentos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
