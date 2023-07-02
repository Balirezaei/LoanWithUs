using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class fieldNamePersonalInformationConfirmation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalCodeConfirmation",
                table: "UserConfirmation",
                newName: "PersonalInformationConfirmation");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 7, 2, 10, 37, 51, 909, DateTimeKind.Local).AddTicks(2690));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalInformationConfirmation",
                table: "UserConfirmation",
                newName: "NationalCodeConfirmation");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 21, 15, 59, 52, 98, DateTimeKind.Local).AddTicks(7802));
        }
    }
}
