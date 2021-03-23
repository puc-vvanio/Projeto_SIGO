using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipos_eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Sistema = table.Column<int>(type: "int", nullable: false),
                    TipoEventoID = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventos_tipos_eventos_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "tipos_eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tipos_eventos",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Nome", "UltimoAcesso" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 3, 23, 9, 32, 57, 181, DateTimeKind.Local).AddTicks(2940), null, "Norma Atualizada", null },
                    { 2, null, new DateTime(2021, 3, 23, 9, 32, 57, 181, DateTimeKind.Local).AddTicks(4693), null, "Norma Cancelada", null },
                    { 3, null, new DateTime(2021, 3, 23, 9, 32, 57, 181, DateTimeKind.Local).AddTicks(4706), null, "Equipamento em Manutenção", null },
                    { 4, null, new DateTime(2021, 3, 23, 9, 32, 57, 181, DateTimeKind.Local).AddTicks(4710), null, "Atraso de Matéria Prima", null },
                    { 5, null, new DateTime(2021, 3, 23, 9, 32, 57, 181, DateTimeKind.Local).AddTicks(4714), null, "Estoque de Produto Acabado", null }
                });

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Sistema", "TipoEventoID", "UltimoAcesso" },
                values: new object[] { 1, null, new DateTime(2021, 3, 23, 9, 32, 57, 183, DateTimeKind.Local).AddTicks(4124), null, "Atualização de versão", "ISO 9001", 1, 1, null });

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Sistema", "TipoEventoID", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(2021, 3, 23, 9, 32, 57, 183, DateTimeKind.Local).AddTicks(6357), null, "Precisa realizar manutenção prenventiva", "Rebobinadeira longitudinal", 3, 3, null });

            migrationBuilder.InsertData(
                table: "eventos",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Sistema", "TipoEventoID", "UltimoAcesso" },
                values: new object[] { 3, null, new DateTime(2021, 3, 23, 9, 32, 57, 183, DateTimeKind.Local).AddTicks(6364), null, "1000 metros do tecido AX2001 liberado para venda", "Liberação de produto", 5, 5, null });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "eventos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_eventos_TipoEventoID",
                table: "eventos",
                column: "TipoEventoID");

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "tipos_eventos",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "tipos_eventos");
        }
    }
}
