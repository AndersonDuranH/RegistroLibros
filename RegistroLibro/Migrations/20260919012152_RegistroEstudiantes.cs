using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using RegistroLibro.Context;

namespace RegistroLibro.Migrations;

[DbContext(typeof(Contexto))]
[Migration("20260919012152_RegistroEstudiantes")]
public partial class RegistroEstudiantes : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Libros");
        migrationBuilder.CreateTable(
            name: "Estudiantes",
            columns: table => new
            {
                EstudianteId = table.Column<int>(type: "INTEGER", nullable: false).Annotation("Sqlite:Autoincrement", true),
                Nombres = table.Column<string>(type: "TEXT", nullable: false),
                Direccion = table.Column<string>(type: "TEXT", nullable: false),
                Email = table.Column<string>(type: "TEXT", nullable: false),
                FechaNacimiento = table.Column<DateOnly>(type: "TEXT", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId));
    }
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Estudiantes");
        migrationBuilder.CreateTable(
            name: "Libros",
            columns: table => new
            {
                LibroId = table.Column<int>(type: "INTEGER", nullable: false).Annotation("Sqlite:Autoincrement", true),
                AnoPublicacion = table.Column<int>(type: "INTEGER", nullable: false),
                Autor = table.Column<string>(type: "TEXT", nullable: false),
                Titulo = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Libros", x => x.LibroId));
    }
}