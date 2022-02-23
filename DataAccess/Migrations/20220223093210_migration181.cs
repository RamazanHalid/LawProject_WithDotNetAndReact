using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cityCountryIdFK",
                table: "Cities");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.AddForeignKey(
                name: "cityCountryIdFK",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
