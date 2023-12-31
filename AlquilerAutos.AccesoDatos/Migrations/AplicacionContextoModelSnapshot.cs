﻿// <auto-generated />
using System;
using AlquilerAutos.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlquilerAutos.AccesoDatos.Migrations
{
    [DbContext(typeof(AplicacionContexto))]
    partial class AplicacionContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlquilerAutos.Entidades.FormaDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormaDePagos");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<int>("IdFormaDePago")
                        .HasColumnType("int");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("IdPago");

                    b.HasIndex("IdFormaDePago");

                    b.HasIndex("IdReserva");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.TipoCombustible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoCombustibles");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoriaCarnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Dni")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimientoCarnet")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehiculo"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPasajeron")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPuertas")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadBaul")
                        .HasColumnType("int");

                    b.Property<int>("CapacidadCombustible")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoCombustible")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioPorDia")
                        .HasColumnType("float");

                    b.HasKey("IdVehiculo");

                    b.HasIndex("IdTipoCombustible");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Pago", b =>
                {
                    b.HasOne("AlquilerAutos.Entidades.FormaDePago", "FormasDePagos")
                        .WithMany("Pagos")
                        .HasForeignKey("IdFormaDePago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlquilerAutos.Entidades.Reserva", "Reserva")
                        .WithMany("Pagos")
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormasDePagos");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Reserva", b =>
                {
                    b.HasOne("AlquilerAutos.Entidades.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlquilerAutos.Entidades.Vehiculo", "Vehiculo")
                        .WithMany("Reservas")
                        .HasForeignKey("IdVehiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Vehiculo", b =>
                {
                    b.HasOne("AlquilerAutos.Entidades.TipoCombustible", "TiposDeCombustibles")
                        .WithMany("Vehiculos")
                        .HasForeignKey("IdTipoCombustible")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposDeCombustibles");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.FormaDePago", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Reserva", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.TipoCombustible", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("AlquilerAutos.Entidades.Vehiculo", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
