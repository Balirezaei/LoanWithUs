using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class addressInformation_province : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "UserDocument");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AddressInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 7, 10, 10, 11, 23, 901, DateTimeKind.Local).AddTicks(8309));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressInformation");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AddressInformation");

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "UserDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 7, 3, 8, 54, 44, 882, DateTimeKind.Local).AddTicks(2974));
        }
    }
}
