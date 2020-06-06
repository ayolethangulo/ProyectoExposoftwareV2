using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    IdArea = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    IdAsignatura = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NombreArea = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.IdAsignatura);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    IdCalificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IdRubrica = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.IdCalificacion);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionesC",
                columns: table => new
                {
                    IdDescripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCalificacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionesC", x => x.IdDescripcion);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NombreArea = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TipoDocente = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante1 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante2 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante3 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante4 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante5 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante6 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante7 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante8 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante9 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Estudiante10 = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.IdInscripcion);
                });

        
            migrationBuilder.CreateTable(
                name: "Pendons",
                columns: table => new
                {
                    IdPendon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Introduccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendons", x => x.IdPendon);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Asignatura = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Semestre = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodologia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.IdProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Rubricas",
                columns: table => new
                {
                    IdRubrica = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    IdArea = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubricas", x => x.IdRubrica);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    User = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    TipoDocente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.User);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "DescripcionesC");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Pendons");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Rubricas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
