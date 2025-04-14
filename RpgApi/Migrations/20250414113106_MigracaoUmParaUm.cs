using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 110, 10, 97, 251, 231, 91, 83, 249, 15, 20, 81, 3, 131, 46, 209, 6, 197, 179, 134, 90, 190, 28, 98, 236, 188, 167, 26, 236, 219, 33, 81, 37, 26, 23, 6, 65, 13, 48, 43, 157, 107, 44, 55, 120, 82, 241, 253, 131, 177, 159, 116, 49, 115, 92, 72, 167, 22, 116, 196, 68, 124, 7, 205, 226 }, new byte[] { 239, 230, 161, 129, 150, 227, 71, 169, 61, 220, 233, 252, 26, 47, 89, 13, 110, 237, 97, 178, 44, 97, 119, 173, 95, 221, 225, 202, 188, 70, 70, 167, 161, 90, 237, 137, 109, 143, 5, 51, 40, 177, 191, 116, 169, 215, 165, 63, 139, 245, 226, 7, 246, 15, 91, 171, 184, 195, 157, 177, 64, 42, 64, 90, 76, 59, 170, 168, 80, 194, 85, 56, 15, 213, 203, 163, 137, 227, 168, 205, 31, 24, 163, 65, 30, 217, 86, 165, 63, 39, 248, 137, 30, 160, 244, 178, 56, 213, 101, 204, 145, 130, 11, 151, 16, 217, 247, 213, 53, 197, 213, 218, 217, 196, 253, 25, 160, 190, 175, 143, 91, 118, 11, 25, 9, 170, 211, 228 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 54, 126, 48, 213, 207, 118, 253, 148, 141, 145, 133, 52, 250, 151, 35, 146, 70, 94, 212, 6, 153, 154, 146, 249, 137, 212, 54, 127, 204, 39, 243, 60, 117, 106, 148, 93, 241, 166, 123, 184, 73, 187, 84, 240, 174, 185, 162, 123, 136, 92, 233, 170, 152, 83, 229, 232, 252, 93, 74, 151, 225, 236, 189 }, new byte[] { 206, 67, 187, 34, 170, 20, 227, 35, 138, 80, 254, 30, 225, 191, 200, 18, 9, 176, 252, 199, 176, 3, 161, 29, 222, 27, 10, 28, 107, 141, 90, 203, 247, 51, 236, 166, 10, 182, 211, 88, 232, 8, 17, 112, 75, 4, 42, 251, 67, 104, 152, 80, 182, 135, 87, 233, 12, 109, 3, 106, 246, 1, 247, 150, 91, 255, 3, 132, 160, 190, 33, 71, 177, 193, 92, 188, 215, 189, 64, 43, 29, 125, 41, 31, 1, 62, 14, 245, 103, 1, 87, 218, 104, 97, 47, 93, 165, 174, 85, 52, 82, 74, 29, 36, 141, 245, 244, 68, 27, 128, 171, 151, 126, 25, 118, 69, 52, 234, 180, 235, 240, 23, 195, 203, 133, 226, 213, 122 } });
        }
    }
}
