using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class laon_remove_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_User_UserId",
                table: "Loan");

            migrationBuilder.DropIndex(
                name: "IX_Loan_UserId",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loan");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 9, 15, 50, 43, 743, DateTimeKind.Local).AddTicks(5832));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Loan",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 9, 10, 10, 35, 229, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.CreateIndex(
                name: "IX_Loan_UserId",
                table: "Loan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_User_UserId",
                table: "Loan",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
