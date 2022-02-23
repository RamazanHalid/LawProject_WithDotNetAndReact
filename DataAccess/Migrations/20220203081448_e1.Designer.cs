﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(HukukContext))]
    [Migration("20220203081448_e1")]
    partial class e1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.CaseStatus", b =>
                {
                    b.Property<int>("CaseStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourtOfficeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionTr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.HasKey("CaseStatusId");

                    b.HasIndex("CourtOfficeTypeId");

                    b.ToTable("CaseStatuses");
                });

            modelBuilder.Entity("Entities.Concrete.CaseType", b =>
                {
                    b.Property<int>("CaseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourtOfficeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionTr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.HasKey("CaseTypeId");

                    b.HasIndex("CourtOfficeTypeId");

                    b.ToTable("CaseTypes");
                });

            modelBuilder.Entity("Entities.Concrete.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Entities.Concrete.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Entities.Concrete.CourtOffice", b =>
                {
                    b.Property<int>("CourtOfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adderess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtOfficeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourtOfficeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPhoneNumberAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("SecondPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondPhoneNumberAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPhoneNumberAdd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtOfficeId");

                    b.ToTable("CourtOffices");
                });

            modelBuilder.Entity("Entities.Concrete.CourtOfficeType", b =>
                {
                    b.Property<int>("CourtOfficeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourtOfficeTypeNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourtOfficeTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourtOfficeTypeId");

                    b.ToTable("CourtOfficeTypes");
                });

            modelBuilder.Entity("Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReference")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("TaxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Concrete.CustomerUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnlineUser")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("MobilePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerUsers");
                });

            modelBuilder.Entity("Entities.Concrete.CustomerUserRelation", b =>
                {
                    b.Property<int>("CustomerUserRelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RelationId")
                        .HasColumnType("int");

                    b.Property<int>("RelationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SideId")
                        .HasColumnType("int");

                    b.HasKey("CustomerUserRelationId");

                    b.ToTable("CustomerUserRelations");
                });

            modelBuilder.Entity("Entities.Concrete.Licence", b =>
                {
                    b.Property<int>("LicenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("BillAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("DemoDay")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gb")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastBillDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MinuseBalanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SmsAccountId")
                        .HasColumnType("int");

                    b.Property<int>("SmsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.HasKey("LicenceId");

                    b.HasIndex("CityId");

                    b.ToTable("Licences");
                });

            modelBuilder.Entity("Entities.Concrete.LicenceUser", b =>
                {
                    b.Property<int>("LicenceUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LicenceUserId");

                    b.HasIndex("LicenceId");

                    b.ToTable("LicenceUsers");
                });

            modelBuilder.Entity("Entities.Concrete.PersonType", b =>
                {
                    b.Property<int>("PersonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonTypeNameEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonTypeId");

                    b.ToTable("PersonTypes");
                });

            modelBuilder.Entity("Entities.Concrete.ProcessType", b =>
                {
                    b.Property<int>("ProcessTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("ProcessTypeNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcessTypeId");

                    b.ToTable("ProcessTypes");
                });

            modelBuilder.Entity("Entities.Concrete.TaskType", b =>
                {
                    b.Property<int>("TaskTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("TaskTypeNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("Entities.Concrete.TransactionActivitySubType", b =>
                {
                    b.Property<int>("TransactionAcitivitySubTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionAcitivitySubTypeNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionAcitivitySubTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionAcitivityTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionActivityTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionAcitivitySubTypeId");

                    b.HasIndex("TransactionActivityTypeId");

                    b.ToTable("TransactionAcitivitySubTypes");
                });

            modelBuilder.Entity("Entities.Concrete.TransactionActivityType", b =>
                {
                    b.Property<int>("TransactionActivityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TransactionActivityTypeNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionActivityTypeNameTr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionActivityTypeId");

                    b.ToTable("TransactionActivityTypes");
                });

            modelBuilder.Entity("Entities.Concrete.CaseStatus", b =>
                {
                    b.HasOne("Entities.Concrete.CourtOfficeType", "CourtOfficeType")
                        .WithMany()
                        .HasForeignKey("CourtOfficeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.CaseType", b =>
                {
                    b.HasOne("Entities.Concrete.CourtOfficeType", "CourtOfficeType")
                        .WithMany()
                        .HasForeignKey("CourtOfficeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.City", b =>
                {
                    b.HasOne("Entities.Concrete.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Customer", b =>
                {
                    b.HasOne("Entities.Concrete.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Licence", b =>
                {
                    b.HasOne("Entities.Concrete.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.LicenceUser", b =>
                {
                    b.HasOne("Entities.Concrete.Licence", "Licence")
                        .WithMany()
                        .HasForeignKey("LicenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.TransactionActivitySubType", b =>
                {
                    b.HasOne("Entities.Concrete.TransactionActivityType", "TransactionActivityType")
                        .WithMany()
                        .HasForeignKey("TransactionActivityTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
