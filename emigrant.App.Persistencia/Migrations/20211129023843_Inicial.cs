using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace emigrant.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emergencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmergencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMigrante = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumetoMigrante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreMigrante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntidadColaboradora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadColaboradora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Migrantes",
                columns: table => new
                {
                    MigranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaisOrigen = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirrecionElectronica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadResidencia = table.Column<int>(type: "int", nullable: false),
                    SituacionLaboral = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrantes", x => x.MigranteId);
                });

            migrationBuilder.CreateTable(
                name: "ServicioAsignaciones",
                columns: table => new
                {
                    ServicioAsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    EntidadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    ServicioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MigranteId = table.Column<int>(type: "int", nullable: false),
                    MigranteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioAsignaciones", x => x.ServicioAsignacionId);
                });

            migrationBuilder.CreateTable(
                name: "ServicioEnUsos",
                columns: table => new
                {
                    ServicioEnUsoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    MigranteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioEnUsos", x => x.ServicioEnUsoId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    EntidadNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximoMigrantes = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoServicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "ServicioSolicitudes",
                columns: table => new
                {
                    ServicioSolicitudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    EntidadNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    ServicioNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MigranteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MigranteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioSolicitudes", x => x.ServicioSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "AmigoFamiliars",
                columns: table => new
                {
                    AmigoFamiliarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamAmigId = table.Column<int>(type: "int", nullable: false),
                    MigranteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmigoFamiliars", x => x.AmigoFamiliarId);
                    table.ForeignKey(
                        name: "FK_AmigoFamiliars_Migrantes_MigranteId",
                        column: x => x.MigranteId,
                        principalTable: "Migrantes",
                        principalColumn: "MigranteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmigoFamiliars_MigranteId",
                table: "AmigoFamiliars",
                column: "MigranteId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadColaboradora_Nit",
                table: "EntidadColaboradora",
                column: "Nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_NumeroDocumento",
                table: "Migrantes",
                column: "NumeroDocumento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmigoFamiliars");

            migrationBuilder.DropTable(
                name: "Emergencias");

            migrationBuilder.DropTable(
                name: "EntidadColaboradora");

            migrationBuilder.DropTable(
                name: "ServicioAsignaciones");

            migrationBuilder.DropTable(
                name: "ServicioEnUsos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "ServicioSolicitudes");

            migrationBuilder.DropTable(
                name: "Migrantes");
        }
    }
}
