using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration1016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountActivityStatuses",
                columns: table => new
                {
                    AccountActivityStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivityStatuses", x => x.AccountActivityStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AccountActivityTypes",
                columns: table => new
                {
                    AccountActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivityTypes", x => x.AccountActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CourtOfficeTypes",
                columns: table => new
                {
                    CourtOfficeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtOfficeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtOfficeTypes", x => x.CourtOfficeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaimCategories",
                columns: table => new
                {
                    OperationClaimCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaimCategories", x => x.OperationClaimCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OperationClaimCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    OrderTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.OrderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    PersonTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.PersonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionActivityTypes",
                columns: table => new
                {
                    TransactionActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionActivityTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionActivityTypes", x => x.TransactionActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false),
                    LicenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CellPhone = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    SmsCode = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    LicenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Gb = table.Column<int>(nullable: false),
                    SmsAccountId = table.Column<int>(nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    BillAddress = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    ProfilName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Balance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.LicenceId);
                    table.ForeignKey(
                        name: "FK_Licences_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licences_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "PersonTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountActivities",
                columns: table => new
                {
                    AccountActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    OrderTypeId = table.Column<int>(nullable: false),
                    AccountActivityTypeId = table.Column<int>(nullable: false),
                    AccountActivityStatusId = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Expiry = table.Column<DateTime>(nullable: false),
                    TaxCost = table.Column<float>(nullable: false),
                    Coast = table.Column<float>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivities", x => x.AccountActivityId);
                    table.ForeignKey(
                        name: "FK_AccountActivities_AccountActivityStatuses_AccountActivityStatusId",
                        column: x => x.AccountActivityStatusId,
                        principalTable: "AccountActivityStatuses",
                        principalColumn: "AccountActivityStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountActivities_AccountActivityTypes_AccountActivityTypeId",
                        column: x => x.AccountActivityTypeId,
                        principalTable: "AccountActivityTypes",
                        principalColumn: "AccountActivityTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountActivities_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountActivities_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "OrderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatuses",
                columns: table => new
                {
                    CaseStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatuses", x => x.CaseStatusId);
                    table.ForeignKey(
                        name: "FK_CaseStatuses_CourtOfficeTypes_CourtOfficeTypeId",
                        column: x => x.CourtOfficeTypeId,
                        principalTable: "CourtOfficeTypes",
                        principalColumn: "CourtOfficeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseStatuses_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseTypes",
                columns: table => new
                {
                    CaseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypes", x => x.CaseTypeId);
                    table.ForeignKey(
                        name: "FK_CaseTypes_CourtOfficeTypes_CourtOfficeTypeId",
                        column: x => x.CourtOfficeTypeId,
                        principalTable: "CourtOfficeTypes",
                        principalColumn: "CourtOfficeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseTypes_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtOffices",
                columns: table => new
                {
                    CourtOfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    CourtOfficeName = table.Column<string>(nullable: true),
                    Adderess = table.Column<string>(nullable: true),
                    CityId = table.Column<string>(nullable: true),
                    CityId1 = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtOffices", x => x.CourtOfficeId);
                    table.ForeignKey(
                        name: "FK_CourtOffices_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourtOffices_CourtOfficeTypes_CourtOfficeTypeId",
                        column: x => x.CourtOfficeTypeId,
                        principalTable: "CourtOfficeTypes",
                        principalColumn: "CourtOfficeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourtOffices_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    BillAddress = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenceUsers",
                columns: table => new
                {
                    LicenceUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceUsers", x => x.LicenceUserId);
                    table.ForeignKey(
                        name: "FK_LicenceUsers_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenceUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTypes",
                columns: table => new
                {
                    ProcessTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    ProcessTypeName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTypes", x => x.ProcessTypeId);
                    table.ForeignKey(
                        name: "FK_ProcessTypes_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    TaskTypeName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
                    table.ForeignKey(
                        name: "FK_TaskTypes_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAcitivitySubTypes",
                columns: table => new
                {
                    TransactionAcitivitySubTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionAcitivityTypeId = table.Column<int>(nullable: false),
                    TransactionActivityTypeId = table.Column<int>(nullable: true),
                    LicenceId = table.Column<int>(nullable: false),
                    TransactionAcitivitySubTypeName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAcitivitySubTypes", x => x.TransactionAcitivitySubTypeId);
                    table.ForeignKey(
                        name: "FK_TransactionAcitivitySubTypes_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionAcitivitySubTypes_TransactionActivityTypes_TransactionActivityTypeId",
                        column: x => x.TransactionActivityTypeId,
                        principalTable: "TransactionActivityTypes",
                        principalColumn: "TransactionActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Casees",
                columns: table => new
                {
                    CaseeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    CourtOfficeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CaseTypeId = table.Column<int>(nullable: false),
                    CaseStatusId = table.Column<int>(nullable: false),
                    RoleTypeId = table.Column<int>(nullable: false),
                    CaseNo = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casees", x => x.CaseeId);
                    table.ForeignKey(
                        name: "FK_Casees_CaseStatuses_CaseStatusId",
                        column: x => x.CaseStatusId,
                        principalTable: "CaseStatuses",
                        principalColumn: "CaseStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casees_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "CaseTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casees_CourtOffices_CourtOfficeId",
                        column: x => x.CourtOfficeId,
                        principalTable: "CourtOffices",
                        principalColumn: "CourtOfficeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casees_CourtOfficeTypes_CourtOfficeTypeId",
                        column: x => x.CourtOfficeTypeId,
                        principalTable: "CourtOfficeTypes",
                        principalColumn: "CourtOfficeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casees_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casees_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "LicenceId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Casees_CaseStatusId",
                table: "Casees",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Casees_CaseTypeId",
                table: "Casees",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Casees_CourtOfficeId",
                table: "Casees",
                column: "CourtOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Casees_CourtOfficeTypeId",
                table: "Casees",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Casees_CustomerId",
                table: "Casees",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Casees_LicenceId",
                table: "Casees",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatuses_CourtOfficeTypeId",
                table: "CaseStatuses",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatuses_LicenceId",
                table: "CaseStatuses",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_CourtOfficeTypeId",
                table: "CaseTypes",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_LicenceId",
                table: "CaseTypes",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtOffices_CityId1",
                table: "CourtOffices",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_CourtOffices_CourtOfficeTypeId",
                table: "CourtOffices",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtOffices_LicenceId",
                table: "CourtOffices",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LicenceId",
                table: "Customers",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CityId",
                table: "Licences",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_PersonTypeId",
                table: "Licences",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_UserId",
                table: "Licences",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenceUsers_LicenceId",
                table: "LicenceUsers",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenceUsers_UserId",
                table: "LicenceUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTypes_LicenceId",
                table: "ProcessTypes",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTypes_LicenceId",
                table: "TaskTypes",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAcitivitySubTypes_LicenceId",
                table: "TransactionAcitivitySubTypes",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAcitivitySubTypes_TransactionActivityTypeId",
                table: "TransactionAcitivitySubTypes",
                column: "TransactionActivityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountActivities");

            migrationBuilder.DropTable(
                name: "Casees");

            migrationBuilder.DropTable(
                name: "LicenceUsers");

            migrationBuilder.DropTable(
                name: "OperationClaimCategories");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "ProcessTypes");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "TransactionAcitivitySubTypes");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "AccountActivityStatuses");

            migrationBuilder.DropTable(
                name: "AccountActivityTypes");

            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.DropTable(
                name: "CaseStatuses");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropTable(
                name: "CourtOffices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TransactionActivityTypes");

            migrationBuilder.DropTable(
                name: "CourtOfficeTypes");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
