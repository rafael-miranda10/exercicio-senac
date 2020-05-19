using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class RelacionamentoEmpresaFuncPermitirNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                schema: "Senac",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "Senac",
                table: "Employee",
                column: "CompanyId",
                principalSchema: "Senac",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                schema: "Senac",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
