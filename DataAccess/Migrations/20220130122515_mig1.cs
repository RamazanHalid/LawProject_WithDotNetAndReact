using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryNameTr = table.Column<string>(nullable: true),
                    CountryNameEn = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
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
                    FirstPhoneNumber = table.Column<string>(nullable: true),
                    FirstPhoneNumberAdd = table.Column<string>(nullable: true),
                    SecondPhoneNumber = table.Column<string>(nullable: true),
                    SecondPhoneNumberAdd = table.Column<string>(nullable: true),
                    ThirdPhoneNumber = table.Column<string>(nullable: true),
                    ThirdPhoneNumberAdd = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtOffices", x => x.CourtOfficeId);
                });

            migrationBuilder.CreateTable(
                name: "CourtOfficeTypes",
                columns: table => new
                {
                    CourtOfficeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtOfficeTypeNameTr = table.Column<string>(nullable: true),
                    CourtOfficeTypeNameEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtOfficeTypes", x => x.CourtOfficeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerUserRelations",
                columns: table => new
                {
                    CustomerUserRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserId = table.Column<int>(nullable: false),
                    RelationTypeId = table.Column<int>(nullable: false),
                    RelationId = table.Column<int>(nullable: false),
                    SideId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUserRelations", x => x.CustomerUserRelationId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CustomerUserId = table.Column<int>(nullable: false),
                    LicenceId = table.Column<int>(nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberAdd = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsOnlineUser = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUsers", x => x.Id);
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
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceUsers", x => x.LicenceUserId);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    PersonTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonTypeNameTr = table.Column<string>(nullable: true),
                    PersonTypeNameEnd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.PersonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessTypes",
                columns: table => new
                {
                    ProcessTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    ProcessTypeNameTr = table.Column<string>(nullable: true),
                    ProcessTypeNameEn = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTypes", x => x.ProcessTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    TaskTypeNameTr = table.Column<string>(nullable: true),
                    TaskTypeNameEn = table.Column<string>(nullable: true),
                    IsActive = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionActivityTypes",
                columns: table => new
                {
                    TransactionActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionActivityTypeNameTr = table.Column<string>(nullable: true),
                    TransactionActivityTypeNameEn = table.Column<string>(nullable: true)
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
                    OperationClaimId = table.Column<int>(nullable: false)
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
                    TitleTr = table.Column<string>(nullable: true),
                    TitleEn = table.Column<string>(nullable: true),
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
                name: "CaseStatuses",
                columns: table => new
                {
                    CaseStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    DescriptionTr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "CaseTypes",
                columns: table => new
                {
                    CaseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CourtOfficeTypeId = table.Column<int>(nullable: false),
                    DescriptionTr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "TransactionAcitivitySubTypes",
                columns: table => new
                {
                    TransactionAcitivitySubTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionAcitivityTypeNameId = table.Column<int>(nullable: false),
                    TransactionActivityTypeId = table.Column<int>(nullable: true),
                    LicenceId = table.Column<int>(nullable: false),
                    TransactionAcitivitySubTypeNameTr = table.Column<string>(nullable: true),
                    TransactionAcitivitySubTypeNameEn = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAcitivitySubTypes", x => x.TransactionAcitivitySubTypeId);
                    table.ForeignKey(
                        name: "FK_TransactionAcitivitySubTypes_TransactionActivityTypes_TransactionActivityTypeId",
                        column: x => x.TransactionActivityTypeId,
                        principalTable: "TransactionActivityTypes",
                        principalColumn: "TransactionActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenceId = table.Column<int>(nullable: false),
                    CustomerTypeId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    IsReference = table.Column<bool>(nullable: false),
                    BillAddress = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    LicenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Profil = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    DemoDay = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Gb = table.Column<int>(nullable: false),
                    SmsAccountId = table.Column<int>(nullable: false),
                    SmsCount = table.Column<int>(nullable: false),
                    UserCount = table.Column<int>(nullable: false),
                    PersonTypeId = table.Column<int>(nullable: false),
                    BillAddress = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false),
                    ProfilName = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    Balance = table.Column<float>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    MinuseBalanceDate = table.Column<DateTime>(nullable: false),
                    LastBillDate = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseStatuses_CourtOfficeTypeId",
                table: "CaseStatuses",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_CourtOfficeTypeId",
                table: "CaseTypes",
                column: "CourtOfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CityId",
                table: "Licences",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAcitivitySubTypes_TransactionActivityTypeId",
                table: "TransactionAcitivitySubTypes",
                column: "TransactionActivityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseStatuses");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropTable(
                name: "CourtOffices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerUserRelations");

            migrationBuilder.DropTable(
                name: "CustomerUsers");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "LicenceUsers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "ProcessTypes");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "TransactionAcitivitySubTypes");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CourtOfficeTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TransactionActivityTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
