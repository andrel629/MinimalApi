using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Id", "Email", "Perfil", "Senha" },
                values: new object[] { 1, "adm@gmail.com", "Adm", "123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
