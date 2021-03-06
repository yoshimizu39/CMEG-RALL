﻿// <auto-generated />
using System;
using CMEG.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMEG.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200708000436_EquipoMantenimiento")]
    partial class EquipoMantenimiento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMEG.Web.Data.Entities.CentroAsistencial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("CentrosAsistenciales");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.DetalleMantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("FechaEjecucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MantenimientoId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroOTM")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Persona")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("MantenimientoId");

                    b.ToTable("DetalleMantenimiento");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUC")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CentroAsistencialId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Etiqueta")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("FechaCulminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInstalacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Garantia")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Licitacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int?>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("Otms")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("TipoGarantia")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CentroAsistencialId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AñoEjecucion")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("FechaProgramacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroMantenimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.DetalleMantenimiento", b =>
                {
                    b.HasOne("CMEG.Web.Data.Entities.Equipo", "Equipo")
                        .WithMany("Mantenimientos")
                        .HasForeignKey("EquipoId");

                    b.HasOne("CMEG.Web.Data.Entities.Mantenimiento", "Mantenimiento")
                        .WithMany("DetalleMantenimientos")
                        .HasForeignKey("MantenimientoId");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Equipo", b =>
                {
                    b.HasOne("CMEG.Web.Data.Entities.CentroAsistencial", "CentroAsistencial")
                        .WithMany("Equipos")
                        .HasForeignKey("CentroAsistencialId");

                    b.HasOne("CMEG.Web.Data.Entities.Empresa", "Empresa")
                        .WithMany("Equipos")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("CMEG.Web.Data.Entities.Marca", "Marca")
                        .WithMany("Equipos")
                        .HasForeignKey("MarcaId");

                    b.HasOne("CMEG.Web.Data.Entities.Modelo", "Modelo")
                        .WithMany("Equipos")
                        .HasForeignKey("ModeloId");
                });

            modelBuilder.Entity("CMEG.Web.Data.Entities.Mantenimiento", b =>
                {
                    b.HasOne("CMEG.Web.Data.Entities.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");
                });
#pragma warning restore 612, 618
        }
    }
}
