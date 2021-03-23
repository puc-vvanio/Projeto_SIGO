using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.Normas.Infrastructure.Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "normas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "repositorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    URL_API = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "normas",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "NomeArquivo", "Status", "Tipo", "UltimoAcesso" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(1776), null, "Sistema de Gestao da Qualidade", "ISO 9001", "ISO9001.pdf", 0, 2, null },
                    { 2, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(4363), null, "Sistema de Gestao Ambiental", "ISO 14001", "ISO14001.pdf", 0, 2, null },
                    { 3, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(4370), null, "Sistema de Gestao de Seguranca da Informacao", "ISO 27001", "ISO27001.pdf", 0, 2, null },
                    { 4, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(4372), null, "Servicos Especializados em Eng. de Seguranca e em Medicina do Trabalho", "NR 4", "NR4.pdf", 0, 2, null },
                    { 5, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(4374), null, "Equipamentos de Protecao Individual - EPI", "NR 6", "NR6.pdf", 0, 2, null },
                    { 6, null, new DateTime(2021, 3, 23, 9, 29, 2, 508, DateTimeKind.Local).AddTicks(4376), null, "Programas de Controle Medico de Saude Ocupacional - PCMSO", "NR 7", "NR7.pdf", 0, 2, null }
                });

            migrationBuilder.InsertData(
                table: "repositorios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Senha", "URL_API", "UltimoAcesso", "Usuario" },
                values: new object[] { 1, null, new DateTime(2021, 3, 23, 9, 29, 2, 511, DateTimeKind.Local).AddTicks(2915), null, "Repositorio de Normas Fake 1", "Repositorio 1", "sigo", "http://162.243.37.75/normas", null, "sigo" });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "normas",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "repositorios",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "normas");

            migrationBuilder.DropTable(
                name: "repositorios");
        }
    }
}
