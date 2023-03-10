// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante.Datos;

#nullable disable

namespace Restaurante.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230224002953_agregamosinterrogacionmesapedido")]
    partial class agregamosinterrogacionmesapedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurante.Models.Adicionale", b =>
                {
                    b.Property<int>("AdicionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdicionId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("AdicionId")
                        .HasName("PK__Adiciona__2AAEE60248EC00CA");

                    b.ToTable("Adicionales");
                });

            modelBuilder.Entity("Restaurante.Models.Bebida", b =>
                {
                    b.Property<int>("BebiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BebiId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("BebiId")
                        .HasName("PK__Bebidas__2B7EFA0C869A4B2D");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("Restaurante.Models.Ejecutivo", b =>
                {
                    b.Property<int>("EjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EjeId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<int?>("Cantidades")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("EjeId")
                        .HasName("PK__Ejecutiv__CB70E162AB055F7B");

                    b.ToTable("Ejecutivos");
                });

            modelBuilder.Entity("Restaurante.Models.Ensalada", b =>
                {
                    b.Property<int>("EnsalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnsalaId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("EnsalaId")
                        .HasName("PK__Ensalada__ECFAC1D86DDD85DC");

                    b.ToTable("Ensaladas");
                });

            modelBuilder.Entity("Restaurante.Models.Especiale", b =>
                {
                    b.Property<int>("EspecialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("EspecialId")
                        .HasName("PK__Especial__8F2E66C9C70B9E2E");

                    b.ToTable("Especiales");
                });

            modelBuilder.Entity("Restaurante.Models.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFac")
                        .HasColumnType("date");

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("Opservaciones")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValTotal")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("FacturaId")
                        .HasName("PK__Factura__5C0248654366D446");

                    b.HasIndex("MesaId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Restaurante.Models.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesaId"));

                    b.Property<int?>("AdicionId")
                        .HasColumnType("int");

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<int?>("BebiId")
                        .HasColumnType("int");

                    b.Property<int?>("EjeId")
                        .HasColumnType("int");

                    b.Property<int?>("EnsalaId")
                        .HasColumnType("int");

                    b.Property<int?>("EspecialId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("PrinciId")
                        .HasColumnType("int");

                    b.Property<int?>("ProteId")
                        .HasColumnType("int");

                    b.Property<int?>("SopaId")
                        .HasColumnType("int");

                    b.HasKey("MesaId")
                        .HasName("PK__Mesas__6A4196E8E25997D1");

                    b.HasIndex("AdicionId");

                    b.HasIndex("BebiId");

                    b.HasIndex("EjeId");

                    b.HasIndex("EnsalaId");

                    b.HasIndex("EspecialId");

                    b.HasIndex("PrinciId");

                    b.HasIndex("ProteId");

                    b.HasIndex("SopaId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Pedido", b =>
                {
                    b.Property<int?>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PedidoId"));

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("MesaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Restaurante.Models.Principio", b =>
                {
                    b.Property<int>("PrinciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrinciId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("PrinciId")
                        .HasName("PK__Principi__76D4C3642C032072");

                    b.ToTable("Principios");
                });

            modelBuilder.Entity("Restaurante.Models.Proteina", b =>
                {
                    b.Property<int>("ProteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProteId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("ProteId")
                        .HasName("PK__Proteina__46E02E5501757500");

                    b.ToTable("Proteinas");
                });

            modelBuilder.Entity("Restaurante.Models.Sopa", b =>
                {
                    b.Property<int>("SopaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SopaId"));

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Porciones")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("SopaId")
                        .HasName("PK__Sopas__3899493633CBC8DF");

                    b.ToTable("Sopas");
                });

            modelBuilder.Entity("Restaurante.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("BHABILITADO")
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("UsuarioId")
                        .HasName("PK__Usuario__2B3DE7B8E3594A19");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Restaurante.Models.Factura", b =>
                {
                    b.HasOne("Restaurante.Models.Mesa", "Mesa")
                        .WithMany("Facturas")
                        .HasForeignKey("MesaId")
                        .HasConstraintName("fk_Factura_Mesas");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Restaurante.Models.Mesa", b =>
                {
                    b.HasOne("Restaurante.Models.Adicionale", "Adicion")
                        .WithMany("Mesas")
                        .HasForeignKey("AdicionId")
                        .HasConstraintName("fk_Mesa_Adicionales");

                    b.HasOne("Restaurante.Models.Bebida", "Bebi")
                        .WithMany("Mesas")
                        .HasForeignKey("BebiId")
                        .HasConstraintName("fk_Mesa_Bebidas");

                    b.HasOne("Restaurante.Models.Ejecutivo", "Eje")
                        .WithMany("Mesas")
                        .HasForeignKey("EjeId")
                        .HasConstraintName("fk_Mesa_Ejecutivos");

                    b.HasOne("Restaurante.Models.Ensalada", "Ensala")
                        .WithMany("Mesas")
                        .HasForeignKey("EnsalaId")
                        .HasConstraintName("fk_Mesa_Ensaladas");

                    b.HasOne("Restaurante.Models.Especiale", "Especial")
                        .WithMany("Mesas")
                        .HasForeignKey("EspecialId")
                        .HasConstraintName("fk_Mesa_Especiales");

                    b.HasOne("Restaurante.Models.Principio", "Princi")
                        .WithMany("Mesas")
                        .HasForeignKey("PrinciId")
                        .HasConstraintName("fk_Mesa_Principios");

                    b.HasOne("Restaurante.Models.Proteina", "Prote")
                        .WithMany("Mesas")
                        .HasForeignKey("ProteId")
                        .HasConstraintName("fk_Mesa_Proteinas");

                    b.HasOne("Restaurante.Models.Sopa", "Sopa")
                        .WithMany("Mesas")
                        .HasForeignKey("SopaId")
                        .HasConstraintName("fk_Mesa_Sopas");

                    b.Navigation("Adicion");

                    b.Navigation("Bebi");

                    b.Navigation("Eje");

                    b.Navigation("Ensala");

                    b.Navigation("Especial");

                    b.Navigation("Princi");

                    b.Navigation("Prote");

                    b.Navigation("Sopa");
                });

            modelBuilder.Entity("Restaurante.Models.Pedido", b =>
                {
                    b.HasOne("Restaurante.Models.Mesa", "Mesas")
                        .WithMany()
                        .HasForeignKey("MesaId");

                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Adicionale", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Bebida", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Ejecutivo", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Ensalada", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Especiale", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Mesa", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("Restaurante.Models.Principio", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Proteina", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Restaurante.Models.Sopa", b =>
                {
                    b.Navigation("Mesas");
                });
#pragma warning restore 612, 618
        }
    }
}
