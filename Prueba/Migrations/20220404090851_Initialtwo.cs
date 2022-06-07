using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.Migrations
{
    public partial class Initialtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValoracionEspecialista = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Enfermedad = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    User = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.UniqueConstraint("AK_Usuario_User", x => x.User);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NumColegiado = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTarjeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosticoId = table.Column<long>(type: "bigint", nullable: true),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Diagnostico_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnostico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cita_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicosPaciente",
                columns: table => new
                {
                    MedicosId = table.Column<long>(type: "bigint", nullable: false),
                    PacientesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosPaciente", x => new { x.MedicosId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_MedicosPaciente_Medico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicosPaciente_Paciente_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_DiagnosticoId",
                table: "Cita",
                column: "DiagnosticoId",
                unique: true,
                filter: "[DiagnosticoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_MedicoId",
                table: "Cita",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicosPaciente_PacientesId",
                table: "MedicosPaciente",
                column: "PacientesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "MedicosPaciente");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
