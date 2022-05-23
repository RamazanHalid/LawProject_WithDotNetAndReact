using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatSupports",
                columns: table => new
                {
                    ChatSupportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAnswer = table.Column<bool>(nullable: false),
                    LicenceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DoesItRead = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSupports", x => x.ChatSupportId);
                    table.ForeignKey(
                        name: "FK_ChatSupports_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatSupports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatSupports_LicenceId",
                table: "ChatSupports",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSupports_UserId",
                table: "ChatSupports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatSupports");
        }
    }
}
