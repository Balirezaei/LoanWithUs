using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanWithUsFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanWithUsFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_AddressInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    LastEducationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalSubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_EducationalInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConfirmation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    NationalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    UserBanckAccountConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    MobileConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    HomePhoneConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    PostalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    TotalConfirmation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfirmation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_UserConfirmation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserLogin_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserDocument_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDocument_LoanWithUsFile_FileId",
                        column: x => x.FileId,
                        principalTable: "LoanWithUsFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_FileId",
                table: "UserDocument",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressInformation");

            migrationBuilder.DropTable(
                name: "EducationalInformation");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "UserConfirmation");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "LoanWithUsFile");

            migrationBuilder.DropTable(
                name: "Applicant");
        }
    }
}
