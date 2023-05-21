using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class isMale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildrenCount",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "PersonalInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarried",
                table: "PersonalInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MinimumIncome",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 21, 15, 59, 52, 98, DateTimeKind.Local).AddTicks(7802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildrenCount",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "IsMarried",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "MinimumIncome",
                table: "PersonalInformation");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 18, 12, 18, 38, 136, DateTimeKind.Local).AddTicks(3216));
        }
    }
}
