using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaDatos.Migrations
{
    /// <inheritdoc />
    public partial class ConvertirEnRelacionNtoNCursoEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodCurso",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_CursoCodCurso",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "CursoCodCurso",
                table: "Estudiantes");

            migrationBuilder.CreateTable(
                name: "CursoEstudiante",
                columns: table => new
                {
                    CursosCodCurso = table.Column<int>(type: "int", nullable: false),
                    EstudiantesIdEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEstudiante", x => new { x.CursosCodCurso, x.EstudiantesIdEstudiante });
                    table.ForeignKey(
                        name: "FK_CursoEstudiante_Cursos_CursosCodCurso",
                        column: x => x.CursosCodCurso,
                        principalTable: "Cursos",
                        principalColumn: "CodCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoEstudiante_Estudiantes_EstudiantesIdEstudiante",
                        column: x => x.EstudiantesIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoEstudiante_EstudiantesIdEstudiante",
                table: "CursoEstudiante",
                column: "EstudiantesIdEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoEstudiante");

            migrationBuilder.AddColumn<int>(
                name: "CursoCodCurso",
                table: "Estudiantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursoCodCurso",
                table: "Estudiantes",
                column: "CursoCodCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodCurso",
                table: "Estudiantes",
                column: "CursoCodCurso",
                principalTable: "Cursos",
                principalColumn: "CodCurso");
        }
    }
}
