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
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    PrefixNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_City_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "City",
                        principalColumn: "Id");
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountInformation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShabaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInformation", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_AccountInformation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressInformation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInformation", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AddressInformation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicant_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationalInformation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalSubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInformation", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_EducationalInformation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PersonalInformation", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supporter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supporter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supporter_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserConfirmation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NationalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    UserBanckAccountConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    MobileConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    HomePhoneConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    PostalCodeConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    TotalConfirmation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfirmation", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserConfirmation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserDocument_LoanWithUsFile_FileId",
                        column: x => x.FileId,
                        principalTable: "LoanWithUsFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDocument_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "PrefixNumber", "ProvinceId", "Title" },
                values: new object[,]
                {
                    { 1, "041", null, "آذربایجان شرقی" },
                    { 2, "044", null, "آذربایجان غربی" },
                    { 3, "045", null, "اردبیل" },
                    { 4, "041", null, "اصفهان" },
                    { 5, "076", null, "البرز" },
                    { 6, "084", null, "ایلام" },
                    { 7, "077", null, "بوشهر" },
                    { 8, "021", null, "تهران" },
                    { 9, "038", null, "چهارمحال و بختیاری" },
                    { 10, "056", null, "خراسان جنوبی" },
                    { 11, "051", null, "خراسان رضوی" },
                    { 12, "058", null, "خراسان شمالی" },
                    { 13, "061", null, "خوزستان" },
                    { 14, "024", null, "زنجان" },
                    { 15, "023", null, "سمنان" },
                    { 16, "054", null, "سیستان و بلوچستان" },
                    { 17, "071", null, "فارس" },
                    { 18, "028", null, "قزوین" },
                    { 19, "025", null, "قم" },
                    { 20, "087", null, "کردستان" },
                    { 21, "034", null, "کرمان" },
                    { 22, "083", null, "کرمانشاه" },
                    { 23, "074", null, "کهگیلویه و بویراحمد" },
                    { 24, "017", null, "گلستان" },
                    { 25, "013", null, "گیلان" },
                    { 26, "066", null, "لرستان" },
                    { 27, "011", null, "مازندران" },
                    { 28, "086", null, "مرکزی" },
                    { 29, "076", null, "هرمزگان" },
                    { 30, "081", null, "همدان" },
                    { 31, "035", null, "یزد" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "PrefixNumber", "ProvinceId", "Title" },
                values: new object[,]
                {
                    { 32, "021", 8, "تهران" },
                    { 33, "021", 8, "شهریار" },
                    { 34, "021", 8, "اسلامشهر" },
                    { 35, "021", 8, "بهارستان" },
                    { 36, "021", 8, "پاکدشت" },
                    { 37, "021", 8, "ری" },
                    { 38, "021", 8, "قدس" },
                    { 39, "021", 8, "رباط کریم" },
                    { 40, "021", 8, "ورامین" },
                    { 41, "021", 8, "قرچک" },
                    { 42, "021", 8, "پردیس" },
                    { 43, "021", 8, "دماوند" },
                    { 44, "021", 8, "پیشوا" },
                    { 45, "021", 8, "شمیرانات" },
                    { 46, "021", 8, "فیروزکوه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_MobileNumber",
                table: "Applicant",
                column: "MobileNumber",
                unique: true,
                filter: "[MobileNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supporter_MobileNumber",
                table: "Supporter",
                column: "MobileNumber",
                unique: true,
                filter: "[MobileNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_FileId",
                table: "UserDocument",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInformation");

            migrationBuilder.DropTable(
                name: "AddressInformation");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "EducationalInformation");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Supporter");

            migrationBuilder.DropTable(
                name: "UserConfirmation");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "LoanWithUsFile");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
