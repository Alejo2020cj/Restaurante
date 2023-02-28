using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Datos;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adicionale> Adicionales { get; set; }

    public virtual DbSet<Bebida> Bebidas { get; set; }

    public virtual DbSet<Ejecutivo> Ejecutivos { get; set; }

    public virtual DbSet<Ensalada> Ensaladas { get; set; }

    public virtual DbSet<Especiale> Especiales { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Principio> Principios { get; set; }

    public virtual DbSet<Proteina> Proteinas { get; set; }

    public virtual DbSet<Sopa> Sopas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-6AHB6Q3;Database=Restaurante;TrustServerCertificate=True; User ID=render2web;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adicionale>(entity =>
        {
            entity.HasKey(e => e.AdicionId).HasName("PK__Adiciona__2AAEE60248EC00CA");
        });

        modelBuilder.Entity<Bebida>(entity =>
        {
            entity.HasKey(e => e.BebiId).HasName("PK__Bebidas__2B7EFA0C869A4B2D");
        });

        modelBuilder.Entity<Ejecutivo>(entity =>
        {
            entity.HasKey(e => e.EjeId).HasName("PK__Ejecutiv__CB70E162AB055F7B");
        });

        modelBuilder.Entity<Ensalada>(entity =>
        {
            entity.HasKey(e => e.EnsalaId).HasName("PK__Ensalada__ECFAC1D86DDD85DC");
        });

        modelBuilder.Entity<Especiale>(entity =>
        {
            entity.HasKey(e => e.EspecialId).HasName("PK__Especial__8F2E66C9C70B9E2E");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C0248654366D446");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Facturas).HasConstraintName("fk_Factura_Mesas");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesas__6A4196E8E25997D1");

            entity.HasOne(d => d.Adicion).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Adicionales");

            entity.HasOne(d => d.Bebi).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Bebidas");

            entity.HasOne(d => d.Eje).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Ejecutivos");

            entity.HasOne(d => d.Ensala).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Ensaladas");

            entity.HasOne(d => d.Especial).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Especiales");

            entity.HasOne(d => d.Princi).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Principios");

            entity.HasOne(d => d.Prote).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Proteinas");

            entity.HasOne(d => d.Sopa).WithMany(p => p.Mesas).HasConstraintName("fk_Mesa_Sopas");
        });

        modelBuilder.Entity<Principio>(entity =>
        {
            entity.HasKey(e => e.PrinciId).HasName("PK__Principi__76D4C3642C032072");
        });

        modelBuilder.Entity<Proteina>(entity =>
        {
            entity.HasKey(e => e.ProteId).HasName("PK__Proteina__46E02E5501757500");
        });

        modelBuilder.Entity<Sopa>(entity =>
        {
            entity.HasKey(e => e.SopaId).HasName("PK__Sopas__3899493633CBC8DF");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B8E3594A19");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
