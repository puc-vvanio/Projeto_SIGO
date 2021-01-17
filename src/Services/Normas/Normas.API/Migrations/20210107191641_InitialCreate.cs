using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Sigo.Normas.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "normas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "int(2)", nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "normas",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "normas");
        }
    }
}
