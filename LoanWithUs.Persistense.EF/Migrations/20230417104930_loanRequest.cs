using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class loanRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLoanLadder_LoanLadderFrames_LoanLadderFrameId",
                table: "ApplicantLoanLadder");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantLoanLadder_LoanLadderFrameId",
                table: "ApplicantLoanLadder");

            migrationBuilder.DropColumn(
                name: "LoanLadderFrameId",
                table: "ApplicantLoanLadder");

            migrationBuilder.CreateSequence<int>(
                name: "Sequence-TrackingNumber",
                startValue: 1000L);

            migrationBuilder.AlterColumn<string>(
                name: "LastState",
                table: "ApplicantLoanRequest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "ApplicantLoanRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "(FORMAT(GETDATE(), 'yyyy', 'fa')+'/'+cast((NEXT VALUE FOR [Sequence-TrackingNumber]) AS NVARCHAR))");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 17, 14, 19, 29, 807, DateTimeKind.Local).AddTicks(2685));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanLadder_LoanLaddrFrameId",
                table: "ApplicantLoanLadder",
                column: "LoanLaddrFrameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLoanLadder_LoanLadderFrames_LoanLaddrFrameId",
                table: "ApplicantLoanLadder",
                column: "LoanLaddrFrameId",
                principalTable: "LoanLadderFrames",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLoanLadder_LoanLadderFrames_LoanLaddrFrameId",
                table: "ApplicantLoanLadder");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantLoanLadder_LoanLaddrFrameId",
                table: "ApplicantLoanLadder");

            migrationBuilder.DropSequence(
                name: "Sequence-TrackingNumber");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "ApplicantLoanRequest");

            migrationBuilder.AlterColumn<int>(
                name: "LastState",
                table: "ApplicantLoanRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LoanLadderFrameId",
                table: "ApplicantLoanLadder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 12, 17, 52, 2, 347, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanLadder_LoanLadderFrameId",
                table: "ApplicantLoanLadder",
                column: "LoanLadderFrameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLoanLadder_LoanLadderFrames_LoanLadderFrameId",
                table: "ApplicantLoanLadder",
                column: "LoanLadderFrameId",
                principalTable: "LoanLadderFrames",
                principalColumn: "Id");
        }
    }
}
