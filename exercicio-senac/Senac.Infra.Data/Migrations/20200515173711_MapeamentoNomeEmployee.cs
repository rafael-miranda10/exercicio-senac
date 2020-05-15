using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class MapeamentoNomeEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Senac",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Senac",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Senac",
                table: "Employee");
        }
    }
}
