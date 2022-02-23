using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class migration170 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "DemoDay",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "MinuseBalanceDate",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "Profil",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Licences");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Licences");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "CourtOffices",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "CourtOffices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CountryId",
                table: "Licences",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_PersonTypeId",
                table: "Licences",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtOffices_CityId1",
                table: "CourtOffices",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_CourtOffices_CourtOfficeTypeId",
                table: "CourtOffices",
                column: "CourtOfficeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtOffices_Cities_CityId1",
                table: "CourtOffices",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtOffices_CourtOfficeTypes_CourtOfficeTypeId",
                table: "CourtOffices",
                column: "CourtOfficeTypeId",
                principalTable: "CourtOfficeTypes",
                principalColumn: "CourtOfficeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Countries_CountryId",
                table: "Licences",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_PersonTypes_PersonTypeId",
                table: "Licences",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "PersonTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtOffices_Cities_CityId1",
                table: "CourtOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtOffices_CourtOfficeTypes_CourtOfficeTypeId",
                table: "CourtOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Countries_CountryId",
                table: "Licences");

            migrationBuilder.DropForeignKey(
                name: "FK_Licences_PersonTypes_PersonTypeId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_CountryId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_Licences_PersonTypeId",
                table: "Licences");

            migrationBuilder.DropIndex(
                name: "IX_CourtOffices_CityId1",
                table: "CourtOffices");

            migrationBuilder.DropIndex(
                name: "IX_CourtOffices_CourtOfficeTypeId",
                table: "CourtOffices");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "CourtOffices");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Licences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DemoDay",
                table: "Licences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Licences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MinuseBalanceDate",
                table: "Licences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Profil",
                table: "Licences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "X",
                table: "Licences",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Y",
                table: "Licences",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "CourtOffices",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
