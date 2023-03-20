using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class applicant_supporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupporterId",
                table: "Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 3, 20, 14, 52, 3, 999, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_SupporterId",
                table: "Applicant",
                column: "SupporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_Supporter_SupporterId",
                table: "Applicant",
                column: "SupporterId",
                principalTable: "Supporter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Supporter_SupporterId",
                table: "Applicant");

            migrationBuilder.DropIndex(
                name: "IX_Applicant_SupporterId",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "SupporterId",
                table: "Applicant");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 3, 19, 22, 35, 14, 333, DateTimeKind.Local).AddTicks(9889));
        }
    }
}
