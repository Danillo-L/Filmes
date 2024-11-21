using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FILMES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    Bilheteria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FILMES", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_FILMES",
                columns: new[] { "Id", "AnoLancamento", "Bilheteria", "Classificacao", "Duracao", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, 2014, 774000000m, 10, new TimeSpan(0, 2, 49, 0, 0), 3, "Interestelar" },
                    { 2, 2013, 426074373m, 16, new TimeSpan(0, 2, 45, 0, 0), 0, "Django Livre" },
                    { 3, 2016, 340600000m, 0, new TimeSpan(0, 2, 8, 0, 0), 0, "La La Land" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FILMES");
        }
    }
}
