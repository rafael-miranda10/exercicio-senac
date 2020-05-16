using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class RegisterCodeNuable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegisterCode",
                schema: "Senac",
                table: "Employee",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegisterCode",
                schema: "Senac",
                table: "Employee",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
