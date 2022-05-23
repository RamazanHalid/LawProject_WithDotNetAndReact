using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasesUpdateHistories",
                columns: table => new
                {
                    CasesUpdateHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    ByWhichUserId = table.Column<int>(nullable: false),
                    CaseeId = table.Column<int>(nullable: false),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    CourtOfficeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CaseTypeId = table.Column<int>(nullable: false),
                    CaseStatusId = table.Column<int>(nullable: false),
                    RoleTypeId = table.Column<int>(nullable: false),
                    CaseNo = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    IsEnd = table.Column<bool>(nullable: false),
                    HasItBeenDecide = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DoesCourtOfficeTypeChange = table.Column<bool>(nullable: false),
                    DoesCourtOfficeChange = table.Column<bool>(nullable: false),
                    DoesCustomerChange = table.Column<bool>(nullable: false),
                    DoesRoleTypeChange = table.Column<bool>(nullable: false),
                    DoesCaseTypeChange = table.Column<bool>(nullable: false),
                    DoesCaseStatusChange = table.Column<bool>(nullable: false),
                    DoesCaseNoChange = table.Column<bool>(nullable: false),
                    DoesInfoChange = table.Column<bool>(nullable: false),
                    DoesItEndChange = table.Column<bool>(nullable: false),
                    DoesItHasBeenDecideChange = table.Column<bool>(nullable: false),
                    DoesItStartDateChange = table.Column<bool>(nullable: false),
                    DoesItDecisionDateChange = table.Column<bool>(nullable: false),
                    DoesItEndDateChange = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesUpdateHistories", x => x.CasesUpdateHistoryId);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_Users_ByWhichUserId",
                        column: x => x.ByWhichUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_CaseStatuses_CaseStatusId",
                        column: x => x.CaseStatusId,
                        principalTable: "CaseStatuses",
                        principalColumn: "CaseStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "CaseTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_Casees_CaseeId",
                        column: x => x.CaseeId,
                        principalTable: "Casees",
                        principalColumn: "CaseeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_CourtOffices_CourtOfficeId",
                        column: x => x.CourtOfficeId,
                        principalTable: "CourtOffices",
                        principalColumn: "CourtOfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_CourtOfficeTypes_CourtOfficeTypeId",
                        column: x => x.CourtOfficeTypeId,
                        principalTable: "CourtOfficeTypes",
                        principalColumn: "CourtOfficeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasesUpdateHistories_RoleTypes_RoleTypeId",
                        column: x => x.RoleTypeId,
                        principalTable: "RoleTypes",
                        principalColumn: "RoleTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_ByWhichUserId",
                table: "CasesUpdateHistories",
                column: "ByWhichUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CaseStatusId",
                table: "CasesUpdateHistories",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CaseTypeId",
                table: "CasesUpdateHistories",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CaseeId",
                table: "CasesUpdateHistories",
                column: "CaseeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CourtOfficeId",
                table: "CasesUpdateHistories",
                column: "CourtOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CourtOfficeTypeId",
                table: "CasesUpdateHistories",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_CustomerId",
                table: "CasesUpdateHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_LicenceId",
                table: "CasesUpdateHistories",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesUpdateHistories_RoleTypeId",
                table: "CasesUpdateHistories",
                column: "RoleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasesUpdateHistories");
        }
    }
}
