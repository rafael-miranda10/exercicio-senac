using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class RelacionamentoCargoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeePositionId",
                schema: "Senac",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeePositionId",
                schema: "Senac",
                table: "Employee",
                column: "EmployeePositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeePosition_EmployeePositionId",
                schema: "Senac",
                table: "Employee",
                column: "EmployeePositionId",
                principalSchema: "Senac",
                principalTable: "EmployeePosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeePosition_EmployeePositionId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeePositionId",
                schema: "Senac",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeePositionId",
                schema: "Senac",
                table: "Employee");
        }
    }
}
