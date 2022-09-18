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
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanWithUsFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supporter",
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
                    table.PrimaryKey("PK_Supporter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantAddressInformation",
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
                    table.PrimaryKey("PK_ApplicantAddressInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_ApplicantAddressInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantBankAccountInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShabaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantBankAccountInformation", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_ApplicantBankAccountInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantEducationalInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    LastEducationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalSubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEducationalInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_ApplicantEducationalInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPersonalInformation",
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
                    table.PrimaryKey("PK_ApplicantPersonalInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_ApplicantPersonalInformation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantUserConfirmation",
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
                    table.PrimaryKey("PK_ApplicantUserConfirmation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_ApplicantUserConfirmation_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantUserLogin",
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
                    table.PrimaryKey("PK_ApplicantUserLogin", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_ApplicantUserLogin_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantUserDocument",
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
                    table.PrimaryKey("PK_ApplicantUserDocument", x => new { x.ApplicantId, x.Id });
                    table.ForeignKey(
                        name: "FK_ApplicantUserDocument_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantUserDocument_LoanWithUsFile_FileId",
                        column: x => x.FileId,
                        principalTable: "LoanWithUsFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterAddressInformation",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SupporterAddressInformation", x => x.SupporterId);
                    table.ForeignKey(
                        name: "FK_SupporterAddressInformation_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterBankAccountInformation",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShabaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterBankAccountInformation", x => new { x.SupporterId, x.Id });
                    table.ForeignKey(
                        name: "FK_SupporterBankAccountInformation_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterEducationalInformation",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    LastEducationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalSubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterEducationalInformation", x => x.SupporterId);
                    table.ForeignKey(
                        name: "FK_SupporterEducationalInformation_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterPersonalInformation",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SupporterPersonalInformation", x => x.SupporterId);
                    table.ForeignKey(
                        name: "FK_SupporterPersonalInformation_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterUserConfirmation",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    NationalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    UserBanckAccountConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    MobileConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    HomePhoneConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    PostalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    TotalConfirmation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterUserConfirmation", x => x.SupporterId);
                    table.ForeignKey(
                        name: "FK_SupporterUserConfirmation_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterUserDocument",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterUserDocument", x => new { x.SupporterId, x.Id });
                    table.ForeignKey(
                        name: "FK_SupporterUserDocument_LoanWithUsFile_FileId",
                        column: x => x.FileId,
                        principalTable: "LoanWithUsFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupporterUserDocument_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupporterUserLogin",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterUserLogin", x => new { x.SupporterId, x.Id });
                    table.ForeignKey(
                        name: "FK_SupporterUserLogin_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_MobileNumber",
                table: "Applicant",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantUserDocument_FileId",
                table: "ApplicantUserDocument",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Supporter_MobileNumber",
                table: "Supporter",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupporterUserDocument_FileId",
                table: "SupporterUserDocument",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAddressInformation");

            migrationBuilder.DropTable(
                name: "ApplicantBankAccountInformation");

            migrationBuilder.DropTable(
                name: "ApplicantEducationalInformation");

            migrationBuilder.DropTable(
                name: "ApplicantPersonalInformation");

            migrationBuilder.DropTable(
                name: "ApplicantUserConfirmation");

            migrationBuilder.DropTable(
                name: "ApplicantUserDocument");

            migrationBuilder.DropTable(
                name: "ApplicantUserLogin");

            migrationBuilder.DropTable(
                name: "SupporterAddressInformation");

            migrationBuilder.DropTable(
                name: "SupporterBankAccountInformation");

            migrationBuilder.DropTable(
                name: "SupporterEducationalInformation");

            migrationBuilder.DropTable(
                name: "SupporterPersonalInformation");

            migrationBuilder.DropTable(
                name: "SupporterUserConfirmation");

            migrationBuilder.DropTable(
                name: "SupporterUserDocument");

            migrationBuilder.DropTable(
                name: "SupporterUserLogin");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "LoanWithUsFile");

            migrationBuilder.DropTable(
                name: "Supporter");
        }
    }
}
