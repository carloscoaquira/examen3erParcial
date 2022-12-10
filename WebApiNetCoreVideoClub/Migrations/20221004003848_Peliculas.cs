using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNetCoreVideoClub.Migrations
{
    public partial class Peliculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnCines = table.Column<bool>(type: "bit", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasGeneros",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasGeneros", x => new { x.PeliculaId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_GeneroId",
                table: "PeliculasGeneros",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculasGeneros");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
