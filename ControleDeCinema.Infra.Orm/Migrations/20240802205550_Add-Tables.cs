using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAssento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posicao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ocupado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAssento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGenero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(250)", nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(1000)", nullable: false),
                    EmExibicao = table.Column<bool>(type: "bit", nullable: false),
                    Lancamento = table.Column<DateTime>(type: "date", nullable: false),
                    Genero_Id = table.Column<int>(type: "int", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBFilme_TBGenero_Genero_Id",
                        column: x => x.Genero_Id,
                        principalTable: "TBGenero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBFilme_Genero_Id",
                table: "TBFilme",
                column: "Genero_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAssento");

            migrationBuilder.DropTable(
                name: "TBFilme");

            migrationBuilder.DropTable(
                name: "TBGenero");
        }
    }
}
