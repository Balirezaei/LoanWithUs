using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class educationalInfo_educationalSubject_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastEducationLevel",
                table: "EducationalInformation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 7, 13, 13, 34, 45, 126, DateTimeKind.Local).AddTicks(4495));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastEducationLevel",
                table: "EducationalInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 7, 13, 11, 32, 39, 505, DateTimeKind.Local).AddTicks(2143));
        }
    }
}
