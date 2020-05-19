using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class RelacionamentoEmpresaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Senac",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                schema: "Senac",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "Senac",
                table: "Employee",
                column: "CompanyId",
                principalSchema: "Senac",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Senac",
                table: "Employee");
        }
    }
}
