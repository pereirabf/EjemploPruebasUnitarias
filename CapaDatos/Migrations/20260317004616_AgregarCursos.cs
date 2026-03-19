using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoCodCurso",
                table: "Estudiantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CodCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorCodProfesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CodCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Profesores_ProfesorCodProfesor",
                        column: x => x.ProfesorCodProfesor,
                        principalTable: "Profesores",
                        principalColumn: "CodProfesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursoCodCurso",
                table: "Estudiantes",
                column: "CursoCodCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ProfesorCodProfesor",
                table: "Cursos",
                column: "ProfesorCodProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodCurso",
                table: "Estudiantes",
                column: "CursoCodCurso",
                principalTable: "Cursos",
                principalColumn: "CodCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodCurso",
                table: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_CursoCodCurso",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "CursoCodCurso",
                table: "Estudiantes");
        }
    }
}
