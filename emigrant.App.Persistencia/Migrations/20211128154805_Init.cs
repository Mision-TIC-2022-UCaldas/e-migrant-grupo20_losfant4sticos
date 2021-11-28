using Microsoft.EntityFrameworkCore.Migrations;

namespace emigrant.App.Persistencia.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Migrantes");
        }
    }
}
