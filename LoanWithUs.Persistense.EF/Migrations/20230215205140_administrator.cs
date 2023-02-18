using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class administrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "UserLogin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "UserLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => new { x.AdministratorId, x.Id });
                    table.ForeignKey(
                        name: "FK_AdminLogin_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "FirstName", "LastName", "MobileNumber", "NationalCode", "Password", "RegisterationDate", "UserName" },
                values: new object[] { 1, "Admin", "admin", "09124444444", "0099887766", "o4r8d5bV0uH4wxMOIP+8SG8plc4dLZ4iUsgbUonSDL+y1wEWURrhqJEeK7qpyViSZMpVZOhDWbtiEPt00fZr2vWfjKDgEIA8982GNs+Atr2PRpV3+8epUbP6egn4ifS1UsGV3iiZJj3cdMLczNkvBAV05BKi97L+OVQaj4b741gsrDw5p2oa2CE6BLAMAcFfxBpLSuYnLfycfQJlQ7nxP10eSCpeLEpnuX+YqextxzkL1510HPkpJxHspruuijuT3LFMrhqWnNr0e7YuJlft3354QYLkGXAIn2zJYEo/ppfpVXe7IAI9zx7FsLPgXD3z62gEjJHiF+TjeegmDuQ5CA==", new DateTime(2023, 2, 16, 0, 21, 38, 775, DateTimeKind.Local).AddTicks(9177), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "UserLogin");
        }
    }
}
