using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class e1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAcitivityTypeNameId",
                table: "TransactionAcitivitySubTypes");

            migrationBuilder.AddColumn<int>(
                name: "TransactionAcitivityTypeId",
                table: "TransactionAcitivitySubTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAcitivityTypeId",
                table: "TransactionAcitivitySubTypes");

            migrationBuilder.AddColumn<int>(
                name: "TransactionAcitivityTypeNameId",
                table: "TransactionAcitivitySubTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
