using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 199, 144, 163, 154, 57, 84, 63, 161, 116, 126, 7, 120, 120, 135, 189, 22, 82, 145, 214, 251, 194, 43, 157, 126, 78, 160, 48, 56, 211, 163, 99, 174, 147, 26, 117, 203, 63, 67, 14, 131, 149, 160, 97, 180, 117, 99, 116, 18, 116, 215, 84, 230, 246, 170, 101, 36, 30, 68, 254, 245, 164, 178, 229, 119 }, new byte[] { 110, 198, 212, 138, 200, 168, 209, 155, 218, 172, 50, 51, 19, 203, 105, 75, 144, 198, 172, 220, 218, 95, 65, 122, 16, 188, 14, 199, 32, 138, 29, 34, 81, 168, 94, 132, 7, 221, 45, 137, 72, 95, 146, 163, 97, 198, 157, 204, 38, 251, 196, 5, 238, 10, 29, 137, 69, 23, 50, 188, 42, 85, 25, 176, 16, 219, 232, 240, 70, 170, 172, 83, 236, 25, 139, 178, 210, 214, 32, 123, 133, 10, 232, 28, 74, 123, 48, 4, 136, 133, 12, 13, 239, 208, 251, 134, 22, 225, 16, 248, 150, 158, 118, 4, 83, 164, 87, 172, 5, 91, 93, 63, 73, 191, 207, 152, 1, 83, 159, 101, 206, 112, 42, 254, 77, 163, 164, 157 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 110, 10, 97, 251, 231, 91, 83, 249, 15, 20, 81, 3, 131, 46, 209, 6, 197, 179, 134, 90, 190, 28, 98, 236, 188, 167, 26, 236, 219, 33, 81, 37, 26, 23, 6, 65, 13, 48, 43, 157, 107, 44, 55, 120, 82, 241, 253, 131, 177, 159, 116, 49, 115, 92, 72, 167, 22, 116, 196, 68, 124, 7, 205, 226 }, new byte[] { 239, 230, 161, 129, 150, 227, 71, 169, 61, 220, 233, 252, 26, 47, 89, 13, 110, 237, 97, 178, 44, 97, 119, 173, 95, 221, 225, 202, 188, 70, 70, 167, 161, 90, 237, 137, 109, 143, 5, 51, 40, 177, 191, 116, 169, 215, 165, 63, 139, 245, 226, 7, 246, 15, 91, 171, 184, 195, 157, 177, 64, 42, 64, 90, 76, 59, 170, 168, 80, 194, 85, 56, 15, 213, 203, 163, 137, 227, 168, 205, 31, 24, 163, 65, 30, 217, 86, 165, 63, 39, 248, 137, 30, 160, 244, 178, 56, 213, 101, 204, 145, 130, 11, 151, 16, 217, 247, 213, 53, 197, 213, 218, 217, 196, 253, 25, 160, 190, 175, 143, 91, 118, 11, 25, 9, 170, 211, 228 } });
        }
    }
}
