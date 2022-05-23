using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountActivities");

            migrationBuilder.DropTable(
                name: "AccountActivityStatuses");

            migrationBuilder.DropTable(
                name: "AccountActivityTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountActivityStatuses",
                columns: table => new
                {
                    AccountActivityStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivityStatuses", x => x.AccountActivityStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AccountActivityTypes",
                columns: table => new
                {
                    AccountActivityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivityTypes", x => x.AccountActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AccountActivities",
                columns: table => new
                {
                    AccountActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountActivityStatusId = table.Column<int>(type: "int", nullable: false),
                    AccountActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    Coast = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LicenceId = table.Column<int>(type: "int", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    TaxCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivities", x => x.AccountActivityId);
                    table.ForeignKey(
                        name: "FK_AccountActivities_AccountActivityStatuses_AccountActivityStatusId",
                        column: x => x.AccountActivityStatusId,
                        principalTable: "AccountActivityStatuses",
                        principalColumn: "AccountActivityStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountActivities_AccountActivityTypes_AccountActivityTypeId",
                        column: x => x.AccountActivityTypeId,
                        principalTable: "AccountActivityTypes",
                        principalColumn: "AccountActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountActivities_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountActivities_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "OrderTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountActivities_AccountActivityStatusId",
                table: "AccountActivities",
                column: "AccountActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActivities_AccountActivityTypeId",
                table: "AccountActivities",
                column: "AccountActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActivities_LicenceId",
                table: "AccountActivities",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActivities_OrderTypeId",
                table: "AccountActivities",
                column: "OrderTypeId");
        }
    }
}
