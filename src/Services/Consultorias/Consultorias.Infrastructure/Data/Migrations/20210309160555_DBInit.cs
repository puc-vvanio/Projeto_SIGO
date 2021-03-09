using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.Consultorias.Infrastructure.Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ConsultoriaID = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contratos_consultorias_ConsultoriaID",
                        column: x => x.ConsultoriaID,
                        principalTable: "consultorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "consultorias",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "UltimoAcesso" },
                values: new object[] { 1, null, new DateTime(2021, 3, 9, 13, 5, 55, 170, DateTimeKind.Local).AddTicks(4947), null, "Descrição Cosnsultoria 1", "Consultoria 1", null });

            migrationBuilder.InsertData(
                table: "consultorias",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 170, DateTimeKind.Local).AddTicks(6406), null, "Descrição Cosnsultoria 2", "Consultoria 2", null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 1, 1, null, new DateTime(2021, 3, 9, 13, 5, 55, 171, DateTimeKind.Local).AddTicks(9789), null, "Descrição Contrato 1", "Contrato 1", 0, null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 2, 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 172, DateTimeKind.Local).AddTicks(1597), null, "Descrição Contrato 2", "Contrato 2", 1, null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 3, 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 172, DateTimeKind.Local).AddTicks(1603), null, "Descrição Contrato 3", "Contrato 3", 32767, null });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "consultorias",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "contratos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_contratos_ConsultoriaID",
                table: "contratos",
                column: "ConsultoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contratos");

            migrationBuilder.DropTable(
                name: "consultorias");
        }
    }
}
