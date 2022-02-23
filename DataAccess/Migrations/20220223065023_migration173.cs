using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration173 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "licenceCountryIdFK",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_CountryId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Licences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Licences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CountryId",
                table: "Licences",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "licenceCountryIdFK",
                table: "Licences",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
