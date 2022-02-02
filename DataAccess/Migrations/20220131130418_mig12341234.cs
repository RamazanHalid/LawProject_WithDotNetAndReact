using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig12341234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LicenceUsers_LicenceId",
                table: "LicenceUsers",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceUsers_Licences_LicenceId",
                table: "LicenceUsers",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "LicenceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenceUsers_Licences_LicenceId",
                table: "LicenceUsers");

            migrationBuilder.DropIndex(
                name: "IX_LicenceUsers_LicenceId",
                table: "LicenceUsers");
        }
    }
}
