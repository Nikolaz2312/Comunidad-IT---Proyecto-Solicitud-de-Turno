﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TurnoProyecto.Models;

#nullable disable

namespace TurnoProyecto.Migrations
{
    [DbContext(typeof(TurnoContext))]
    partial class TurnoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TurnoProyecto.Models.AsignarTurno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("UserModelDatosuserid")
                        .HasColumnType("int");

                    b.Property<int>("turnoid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserModelDatosuserid");

                    b.HasIndex("turnoid");

                    b.HasIndex("userid");

                    b.ToTable("AsignarDB");
                });

            modelBuilder.Entity("TurnoProyecto.Models.NumeroDeTurnoModelDatos", b =>
                {
                    b.Property<int>("Nturnoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Nturnoid"), 1L, 1);

                    b.Property<int>("Disponible")
                        .HasColumnType("int");

                    b.Property<int>("Ocupados")
                        .HasColumnType("int");

                    b.Property<int>("turnoid")
                        .HasColumnType("int");

                    b.HasKey("Nturnoid");

                    b.HasIndex("turnoid")
                        .IsUnique();

                    b.ToTable("NTurnoDb");
                });

            modelBuilder.Entity("TurnoProyecto.Models.TurnoModelDatos", b =>
                {
                    b.Property<int>("turnoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("turnoid"), 1L, 1);

                    b.Property<DateTime>("aturno")
                        .HasColumnType("datetime2");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fturno")
                        .HasColumnType("datetime2");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("turnoid");

                    b.HasIndex("userid");

                    b.ToTable("TurnoDb");
                });

            modelBuilder.Entity("TurnoProyecto.Models.User2ModelDatos", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"), 1L, 1);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechadenacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("UserSDb");
                });

            modelBuilder.Entity("TurnoProyecto.Models.UserModelDatos", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"), 1L, 1);

                    b.Property<string>("Profesion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechadenacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("UserDb");
                });

            modelBuilder.Entity("TurnoProyecto.Models.AsignarTurno", b =>
                {
                    b.HasOne("TurnoProyecto.Models.UserModelDatos", null)
                        .WithMany("asignarTurnos")
                        .HasForeignKey("UserModelDatosuserid");

                    b.HasOne("TurnoProyecto.Models.TurnoModelDatos", "TurnoModelDatos")
                        .WithMany()
                        .HasForeignKey("turnoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TurnoProyecto.Models.User2ModelDatos", "UserModelDatos")
                        .WithMany("asignarTurnos")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TurnoModelDatos");

                    b.Navigation("UserModelDatos");
                });

            modelBuilder.Entity("TurnoProyecto.Models.NumeroDeTurnoModelDatos", b =>
                {
                    b.HasOne("TurnoProyecto.Models.TurnoModelDatos", "turnoModelDatos")
                        .WithOne("NumeroDeTurnoModelDatos")
                        .HasForeignKey("TurnoProyecto.Models.NumeroDeTurnoModelDatos", "turnoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("turnoModelDatos");
                });

            modelBuilder.Entity("TurnoProyecto.Models.TurnoModelDatos", b =>
                {
                    b.HasOne("TurnoProyecto.Models.UserModelDatos", "UserModelDatos")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModelDatos");
                });

            modelBuilder.Entity("TurnoProyecto.Models.TurnoModelDatos", b =>
                {
                    b.Navigation("NumeroDeTurnoModelDatos")
                        .IsRequired();
                });

            modelBuilder.Entity("TurnoProyecto.Models.User2ModelDatos", b =>
                {
                    b.Navigation("asignarTurnos");
                });

            modelBuilder.Entity("TurnoProyecto.Models.UserModelDatos", b =>
                {
                    b.Navigation("asignarTurnos");
                });
#pragma warning restore 612, 618
        }
    }
}
