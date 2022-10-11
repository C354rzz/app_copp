﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using app_cop.Data;

#nullable disable

namespace app_cop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221011150148_priemra_migracion")]
    partial class priemra_migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("app_cop.Models.Empleados", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdEmpleado");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("ApellidoEmp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Apellidos");

                    b.Property<string>("NombreEmp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Nombre");

                    b.Property<int>("RolId")
                        .HasColumnType("integer")
                        .HasColumnName("RolId");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("RolId");

                    b.ToTable("tbl_empleados");
                });

            modelBuilder.Entity("app_cop.Models.Movimientos", b =>
                {
                    b.Property<int>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdMovimiento");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMovimiento"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer")
                        .HasColumnName("Cantidad");

                    b.Property<decimal>("Costo")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("Costo");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("integer")
                        .HasColumnName("EmpleadoId");

                    b.Property<DateTime>("FechaMov")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("FechaMov");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("integer")
                        .HasColumnName("TipoMovimientoId");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("Total");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("tbl_movimientos");
                });

            modelBuilder.Entity("app_cop.Models.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdRol");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRol"));

                    b.Property<string>("DescripcionRol")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("text")
                        .HasColumnName("Descripcion");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("IdRol");

                    b.ToTable("tbl_roles");
                });

            modelBuilder.Entity("app_cop.Models.TipoMovimientos", b =>
                {
                    b.Property<int>("IdTMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdTipoMovimiento");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTMovimiento"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("Costo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("IdTMovimiento");

                    b.ToTable("tbl_tipoMovimiento");
                });

            modelBuilder.Entity("app_cop.Models.Empleados", b =>
                {
                    b.HasOne("app_cop.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("app_cop.Models.Movimientos", b =>
                {
                    b.HasOne("app_cop.Models.Empleados", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app_cop.Models.TipoMovimientos", "TipoMovimiento")
                        .WithMany()
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("TipoMovimiento");
                });
#pragma warning restore 612, 618
        }
    }
}
