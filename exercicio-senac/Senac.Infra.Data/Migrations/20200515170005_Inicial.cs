using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senac.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Senac");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Senac",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 100, nullable: false),
                    DocNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DocType = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 60, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    AddressNumber = table.Column<string>(nullable: false),
                    AddressNeighborhood = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressState = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "Senac",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DocType = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 60, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 50, nullable: false),
                    AddressNumber = table.Column<string>(nullable: false),
                    AddressNeighborhood = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressState = table.Column<string>(maxLength: 50, nullable: false),
                    RegisterCode = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                schema: "Senac",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ReferenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "Senac");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "Senac");

            migrationBuilder.DropTable(
                name: "EmployeePosition",
                schema: "Senac");
        }
    }
}
