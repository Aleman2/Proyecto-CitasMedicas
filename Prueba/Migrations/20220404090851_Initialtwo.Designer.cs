// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba.Entity;

#nullable disable

namespace Prueba.Migrations
{
    [DbContext(typeof(DataConte))]
    [Migration("20220404090851_Initialtwo")]
    partial class Initialtwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MedicosPaciente", b =>
                {
                    b.Property<long>("MedicosId")
                        .HasColumnType("bigint");

                    b.Property<long>("PacientesId")
                        .HasColumnType("bigint");

                    b.HasKey("MedicosId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("MedicosPaciente");
                });

            modelBuilder.Entity("Prueba.Entity.Cita", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("DiagnosticoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<long>("MedicoId")
                        .HasColumnType("bigint");

                    b.Property<string>("MotivoCita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PacienteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosticoId")
                        .IsUnique()
                        .HasFilter("[DiagnosticoId] IS NOT NULL");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Cita", (string)null);
                });

            modelBuilder.Entity("Prueba.Entity.Diagnostico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Enfermedad")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ValoracionEspecialista")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Diagnostico", (string)null);
                });

            modelBuilder.Entity("Prueba.Entity.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.HasAlternateKey("User");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Prueba.Entity.Medicos", b =>
                {
                    b.HasBaseType("Prueba.Entity.Usuario");

                    b.Property<string>("NumColegiado")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.ToTable("Medico", (string)null);
                });

            modelBuilder.Entity("Prueba.Entity.Paciente", b =>
                {
                    b.HasBaseType("Prueba.Entity.Usuario");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Nss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTarjeta")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("MedicosPaciente", b =>
                {
                    b.HasOne("Prueba.Entity.Medicos", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prueba.Entity.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba.Entity.Cita", b =>
                {
                    b.HasOne("Prueba.Entity.Diagnostico", "Diagnostico")
                        .WithOne("Cita")
                        .HasForeignKey("Prueba.Entity.Cita", "DiagnosticoId");

                    b.HasOne("Prueba.Entity.Medicos", "Medico")
                        .WithMany("Citas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prueba.Entity.Paciente", "Paciente")
                        .WithMany("Citas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnostico");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Prueba.Entity.Medicos", b =>
                {
                    b.HasOne("Prueba.Entity.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Prueba.Entity.Medicos", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba.Entity.Paciente", b =>
                {
                    b.HasOne("Prueba.Entity.Usuario", null)
                        .WithOne()
                        .HasForeignKey("Prueba.Entity.Paciente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba.Entity.Diagnostico", b =>
                {
                    b.Navigation("Cita")
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba.Entity.Medicos", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Prueba.Entity.Paciente", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
