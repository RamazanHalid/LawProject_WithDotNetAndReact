using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenceId",
                table: "CasesDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CasesDocuments_LicenceId",
                table: "CasesDocuments",
                column: "LicenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesDocuments_Licences_LicenceId",
                table: "CasesDocuments",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "LicenceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesDocuments_Licences_LicenceId",
                table: "CasesDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CasesDocuments_LicenceId",
                table: "CasesDocuments");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "CasesDocuments");
        }
    }
}
