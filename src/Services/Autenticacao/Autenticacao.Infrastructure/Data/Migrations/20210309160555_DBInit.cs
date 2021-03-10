using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.Autenticacao.Infrastructure.Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autenticacao",
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
                    table.PrimaryKey("PK_Autenticacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    AutenticacaoID = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_autenticacao_AutenticacaoID",
                        column: x => x.AutenticacaoID,
                        principalTable: "autenticacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "autenticacao",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "UltimoAcesso" },
                values: new object[] { 1, null, new DateTime(2021, 3, 9, 13, 5, 55, 170, DateTimeKind.Local).AddTicks(4947), null, "Descrição Cosnsultoria 1", "Autenticacao 1", null });

            migrationBuilder.InsertData(
                table: "autenticacao",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 170, DateTimeKind.Local).AddTicks(6406), null, "Descrição Cosnsultoria 2", "Autenticacao 2", null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "AutenticacaoID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 1, 1, null, new DateTime(2021, 3, 9, 13, 5, 55, 171, DateTimeKind.Local).AddTicks(9789), null, "Descrição Usuario 1", "Usuario 1", 0, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "AutenticacaoID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 2, 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 172, DateTimeKind.Local).AddTicks(1597), null, "Descrição Usuario 2", "Usuario 2", 1, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "AutenticacaoID", "DataAtualizacao", "DataCriacao", "DataExclusao", "Descricao", "Nome", "Tipo", "UltimoAcesso" },
                values: new object[] { 3, 2, null, new DateTime(2021, 3, 9, 13, 5, 55, 172, DateTimeKind.Local).AddTicks(1603), null, "Descrição Usuario 3", "Usuario 3", 32767, null });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "autenticacao",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "usuarios",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_AutenticacaoID",
                table: "usuarios",
                column: "AutenticacaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "autenticacao");
        }
    }
}
