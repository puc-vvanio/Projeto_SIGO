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
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime", nullable: false),
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
                values: new object[] { 1, null, new DateTime(2021, 3, 23, 9, 20, 13, 251, DateTimeKind.Local).AddTicks(4246), null, "Descrição Cosnsultoria 1", "Consultoria 1", null });

            migrationBuilder.InsertData(
                table: "consultorias",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(2021, 3, 23, 9, 20, 13, 251, DateTimeKind.Local).AddTicks(5664), null, "Descrição Cosnsultoria 2", "Consultoria 2", null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "DataInicio", "DataTermino", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 1, 1, null, new DateTime(2021, 3, 23, 9, 20, 13, 252, DateTimeKind.Local).AddTicks(9579), null, new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição Contrato 1", "Contrato 1", 0, null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "DataInicio", "DataTermino", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 2, 2, null, new DateTime(2021, 3, 23, 9, 20, 13, 253, DateTimeKind.Local).AddTicks(3224), null, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição Contrato 2", "Contrato 2", 1, null });

            migrationBuilder.InsertData(
                table: "contratos",
                columns: new[] { "Id", "ConsultoriaID", "DataAtualizacao", "DataCriacao", "DataExclusao", "DataInicio", "DataTermino", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 3, 2, null, new DateTime(2021, 3, 23, 9, 20, 13, 253, DateTimeKind.Local).AddTicks(3234), null, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição Contrato 3", "Contrato 3", 32767, null });

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
