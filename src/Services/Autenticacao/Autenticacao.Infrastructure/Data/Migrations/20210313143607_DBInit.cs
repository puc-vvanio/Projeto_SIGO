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
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@sigo.com.br", "Usuario 1", (short)32767, new byte[] { 171, 166, 33, 113, 69, 144, 27, 167, 104, 163, 228, 190, 193, 79, 206, 7, 197, 197, 41, 196, 100, 137, 191, 12, 245, 251, 84, 141, 162, 69, 115, 110, 200, 96, 247, 135, 0, 112, 141, 63, 32, 45, 212, 172, 227, 219, 46, 233, 73, 20, 23, 191, 123, 173, 73, 217, 165, 204, 66, 236, 92, 215, 247, 136 }, new byte[] { 14, 54, 239, 130, 244, 60, 199, 122, 65, 90, 77, 54, 202, 221, 126, 250, 243, 187, 17, 156, 223, 26, 230, 8, 99, 160, 0, 112, 90, 133, 145, 88, 253, 198, 250, 248, 133, 46, 216, 90, 181, 177, 148, 248, 60, 62, 144, 237, 240, 213, 241, 171, 84, 176, 58, 114, 159, 19, 43, 39, 73, 58, 154, 61, 197, 79, 151, 250, 154, 232, 211, 217, 210, 52, 118, 209, 45, 8, 166, 180, 40, 7, 93, 24, 21, 234, 94, 200, 151, 107, 196, 78, 53, 189, 25, 11, 80, 174, 135, 238, 193, 100, 40, 122, 75, 129, 15, 151, 235, 7, 12, 37, 93, 114, 22, 16, 31, 240, 35, 158, 105, 202, 136, 24, 201, 137, 13, 179 }, 0, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Email", "Nome", "Perfil", "SenhaHash", "SenhaSalt", "Status", "UltimoAcesso" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "gerente@sigo.com.br", "Usuario 2", (short)1, new byte[] { 171, 166, 33, 113, 69, 144, 27, 167, 104, 163, 228, 190, 193, 79, 206, 7, 197, 197, 41, 196, 100, 137, 191, 12, 245, 251, 84, 141, 162, 69, 115, 110, 200, 96, 247, 135, 0, 112, 141, 63, 32, 45, 212, 172, 227, 219, 46, 233, 73, 20, 23, 191, 123, 173, 73, 217, 165, 204, 66, 236, 92, 215, 247, 136 }, new byte[] { 14, 54, 239, 130, 244, 60, 199, 122, 65, 90, 77, 54, 202, 221, 126, 250, 243, 187, 17, 156, 223, 26, 230, 8, 99, 160, 0, 112, 90, 133, 145, 88, 253, 198, 250, 248, 133, 46, 216, 90, 181, 177, 148, 248, 60, 62, 144, 237, 240, 213, 241, 171, 84, 176, 58, 114, 159, 19, 43, 39, 73, 58, 154, 61, 197, 79, 151, 250, 154, 232, 211, 217, 210, 52, 118, 209, 45, 8, 166, 180, 40, 7, 93, 24, 21, 234, 94, 200, 151, 107, 196, 78, 53, 189, 25, 11, 80, 174, 135, 238, 193, 100, 40, 122, 75, 129, 15, 151, 235, 7, 12, 37, 93, 114, 22, 16, 31, 240, 35, 158, 105, 202, 136, 24, 201, 137, 13, 179 }, 0, null });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "DataExclusao", "Email", "Nome", "Perfil", "SenhaHash", "SenhaSalt", "Status", "UltimoAcesso" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "colaborador@sigo.com.br", "Usuario 3", (short)0, new byte[] { 171, 166, 33, 113, 69, 144, 27, 167, 104, 163, 228, 190, 193, 79, 206, 7, 197, 197, 41, 196, 100, 137, 191, 12, 245, 251, 84, 141, 162, 69, 115, 110, 200, 96, 247, 135, 0, 112, 141, 63, 32, 45, 212, 172, 227, 219, 46, 233, 73, 20, 23, 191, 123, 173, 73, 217, 165, 204, 66, 236, 92, 215, 247, 136 }, new byte[] { 14, 54, 239, 130, 244, 60, 199, 122, 65, 90, 77, 54, 202, 221, 126, 250, 243, 187, 17, 156, 223, 26, 230, 8, 99, 160, 0, 112, 90, 133, 145, 88, 253, 198, 250, 248, 133, 46, 216, 90, 181, 177, 148, 248, 60, 62, 144, 237, 240, 213, 241, 171, 84, 176, 58, 114, 159, 19, 43, 39, 73, 58, 154, 61, 197, 79, 151, 250, 154, 232, 211, 217, 210, 52, 118, 209, 45, 8, 166, 180, 40, 7, 93, 24, 21, 234, 94, 200, 151, 107, 196, 78, 53, 189, 25, 11, 80, 174, 135, 238, 193, 100, 40, 122, 75, 129, 15, 151, 235, 7, 12, 37, 93, 114, 22, 16, 31, 240, 35, 158, 105, 202, 136, 24, 201, 137, 13, 179 }, 0, null });

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
