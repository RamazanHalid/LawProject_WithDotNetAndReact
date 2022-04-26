using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmsAccountId",
                table: "Licences");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Licences",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Licences");

            migrationBuilder.AddColumn<int>(
                name: "SmsAccountId",
                table: "Licences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
