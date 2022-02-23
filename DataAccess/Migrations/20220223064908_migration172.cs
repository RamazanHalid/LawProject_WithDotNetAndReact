using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration172 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Countries_CountryId",
                table: "Licences");

            migrationBuilder.AddForeignKey(
                name: "licenceCountryIdFK",
                table: "Licences",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "licenceCountryIdFK",
                table: "Licences");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Countries_CountryId",
                table: "Licences",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
