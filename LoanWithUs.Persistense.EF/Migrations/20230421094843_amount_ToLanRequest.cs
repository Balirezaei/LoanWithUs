using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class amount_ToLanRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "ApplicantLoanRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 21, 13, 18, 43, 527, DateTimeKind.Local).AddTicks(5534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ApplicantLoanRequest");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 17, 14, 19, 29, 807, DateTimeKind.Local).AddTicks(2685));
        }
    }
}
