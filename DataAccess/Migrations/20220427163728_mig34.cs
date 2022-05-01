using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseIgnoreUsers",
                columns: table => new
                {
                    CaseIgnoreUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CaseeId = table.Column<int>(nullable: false),
                    LicenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseIgnoreUsers", x => x.CaseIgnoreUserId);
                    table.ForeignKey(
                        name: "FK_CaseIgnoreUsers_Casees_CaseeId",
                        column: x => x.CaseeId,
                        principalTable: "Casees",
                        principalColumn: "CaseeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIgnoreUsers_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIgnoreUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseIgnoreUsers_CaseeId",
                table: "CaseIgnoreUsers",
                column: "CaseeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIgnoreUsers_LicenceId",
                table: "CaseIgnoreUsers",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIgnoreUsers_UserId",
                table: "CaseIgnoreUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseIgnoreUsers");
        }
    }
}
