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
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "varbinary(64)", nullable: false),
                    SenhaSalt = table.Column<byte[]>(type: "varbinary(128)", nullable: false),
                    Perfil = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Email", "Nome", "Perfil", "SenhaHash", "SenhaSalt", "Status", "UltimoAcesso" },
                values: new object[] { 1, null, new DateTime(2021, 3, 23, 9, 31, 17, 871, DateTimeKind.Local).AddTicks(9555), null, "admin@sigo.com.br", "Usuario 1", (short)32767, new byte[] { 228, 96, 138, 100, 229, 103, 12, 6, 72, 36, 24, 89, 104, 255, 175, 206, 166, 236, 108, 131, 169, 221, 30, 94, 113, 88, 95, 230, 245, 244, 215, 254, 51, 75, 178, 128, 226, 227, 0, 237, 132, 213, 110, 34, 112, 104, 190, 165, 44, 115, 132, 90, 50, 90, 194, 115, 239, 0, 40, 63, 90, 164, 155, 9 }, new byte[] { 33, 247, 226, 24, 225, 190, 8, 126, 236, 78, 252, 107, 174, 176, 90, 156, 113, 174, 174, 78, 177, 251, 168, 19, 37, 38, 118, 104, 89, 171, 226, 253, 131, 106, 154, 53, 230, 111, 132, 93, 188, 1, 26, 205, 116, 201, 43, 181, 146, 72, 236, 25, 95, 36, 61, 74, 31, 237, 105, 29, 183, 76, 8, 43, 227, 92, 204, 125, 237, 206, 94, 241, 68, 58, 52, 201, 106, 139, 223, 73, 171, 85, 109, 137, 75, 228, 181, 216, 117, 79, 56, 85, 33, 41, 17, 36, 192, 44, 215, 239, 58, 27, 73, 148, 18, 14, 237, 206, 140, 125, 230, 42, 9, 146, 20, 38, 165, 222, 227, 192, 8, 150, 255, 182, 225, 157, 198, 128 }, 0, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Email", "Nome", "Perfil", "SenhaHash", "SenhaSalt", "Status", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(2021, 3, 23, 9, 31, 17, 872, DateTimeKind.Local).AddTicks(2806), null, "gerente@sigo.com.br", "Usuario 2", (short)1, new byte[] { 228, 96, 138, 100, 229, 103, 12, 6, 72, 36, 24, 89, 104, 255, 175, 206, 166, 236, 108, 131, 169, 221, 30, 94, 113, 88, 95, 230, 245, 244, 215, 254, 51, 75, 178, 128, 226, 227, 0, 237, 132, 213, 110, 34, 112, 104, 190, 165, 44, 115, 132, 90, 50, 90, 194, 115, 239, 0, 40, 63, 90, 164, 155, 9 }, new byte[] { 33, 247, 226, 24, 225, 190, 8, 126, 236, 78, 252, 107, 174, 176, 90, 156, 113, 174, 174, 78, 177, 251, 168, 19, 37, 38, 118, 104, 89, 171, 226, 253, 131, 106, 154, 53, 230, 111, 132, 93, 188, 1, 26, 205, 116, 201, 43, 181, 146, 72, 236, 25, 95, 36, 61, 74, 31, 237, 105, 29, 183, 76, 8, 43, 227, 92, 204, 125, 237, 206, 94, 241, 68, 58, 52, 201, 106, 139, 223, 73, 171, 85, 109, 137, 75, 228, 181, 216, 117, 79, 56, 85, 33, 41, 17, 36, 192, 44, 215, 239, 58, 27, 73, 148, 18, 14, 237, 206, 140, 125, 230, 42, 9, 146, 20, 38, 165, 222, 227, 192, 8, 150, 255, 182, 225, 157, 198, 128 }, 0, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Email", "Nome", "Perfil", "SenhaHash", "SenhaSalt", "Status", "UltimoAcesso" },
                values: new object[] { 3, null, new DateTime(2021, 3, 23, 9, 31, 17, 872, DateTimeKind.Local).AddTicks(2815), null, "colaborador@sigo.com.br", "Usuario 3", (short)0, new byte[] { 228, 96, 138, 100, 229, 103, 12, 6, 72, 36, 24, 89, 104, 255, 175, 206, 166, 236, 108, 131, 169, 221, 30, 94, 113, 88, 95, 230, 245, 244, 215, 254, 51, 75, 178, 128, 226, 227, 0, 237, 132, 213, 110, 34, 112, 104, 190, 165, 44, 115, 132, 90, 50, 90, 194, 115, 239, 0, 40, 63, 90, 164, 155, 9 }, new byte[] { 33, 247, 226, 24, 225, 190, 8, 126, 236, 78, 252, 107, 174, 176, 90, 156, 113, 174, 174, 78, 177, 251, 168, 19, 37, 38, 118, 104, 89, 171, 226, 253, 131, 106, 154, 53, 230, 111, 132, 93, 188, 1, 26, 205, 116, 201, 43, 181, 146, 72, 236, 25, 95, 36, 61, 74, 31, 237, 105, 29, 183, 76, 8, 43, 227, 92, 204, 125, 237, 206, 94, 241, 68, 58, 52, 201, 106, 139, 223, 73, 171, 85, 109, 137, 75, 228, 181, 216, 117, 79, 56, 85, 33, 41, 17, 36, 192, 44, 215, 239, 58, 27, 73, 148, 18, 14, 237, 206, 140, 125, 230, 42, 9, 146, 20, 38, 165, 222, 227, 192, 8, 150, 255, 182, 225, 157, 198, 128 }, 0, null });

            migrationBuilder.CreateIndex(
                name: "Idx_Nome",
                table: "usuarios",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
