using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class supporter_debit_Credit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLoanRequestFlow_ApplicantLoanRequest_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantLoanRequestFlow",
                table: "ApplicantLoanRequestFlow");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantLoanRequestFlow_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SupporterCredit",
                newName: "InitialAmount");

            migrationBuilder.CreateSequence<int>(
                name: "Sequence-LoanSerialNumber",
                startValue: 1000L);

            migrationBuilder.AddColumn<string>(
                name: "CurrentBalance",
                table: "SupporterCredit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "Loan",
                type: "int",
                nullable: false,
                defaultValueSql: "(NEXT VALUE FOR [Sequence-LoanSerialNumber])");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "ApplicantLoanRequestFlow",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantLoanRequestFlow",
                table: "ApplicantLoanRequestFlow",
                columns: new[] { "ApplicantLoanRequestId", "Id" });

            migrationBuilder.CreateTable(
                name: "SupporterDebitCreditDetail",
                columns: table => new
                {
                    SupporterCreditSupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterDebitCreditDetail", x => new { x.SupporterCreditSupporterId, x.Id });
                    table.ForeignKey(
                        name: "FK_SupporterDebitCreditDetail_SupporterCredit_SupporterCreditSupporterId",
                        column: x => x.SupporterCreditSupporterId,
                        principalTable: "SupporterCredit",
                        principalColumn: "SupporterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 9, 10, 10, 35, 229, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLoanRequestFlow_ApplicantLoanRequest_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                column: "ApplicantLoanRequestId",
                principalTable: "ApplicantLoanRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantLoanRequestFlow_ApplicantLoanRequest_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow");

            migrationBuilder.DropTable(
                name: "SupporterDebitCreditDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantLoanRequestFlow",
                table: "ApplicantLoanRequestFlow");

            migrationBuilder.DropSequence(
                name: "Sequence-LoanSerialNumber");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "SupporterCredit");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Loan");

            migrationBuilder.RenameColumn(
                name: "InitialAmount",
                table: "SupporterCredit",
                newName: "Amount");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "ApplicantLoanRequestFlow",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantLoanRequestFlow",
                table: "ApplicantLoanRequestFlow",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 7, 15, 2, 14, 604, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanRequestFlow_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                column: "ApplicantLoanRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantLoanRequestFlow_ApplicantLoanRequest_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                column: "ApplicantLoanRequestId",
                principalTable: "ApplicantLoanRequest",
                principalColumn: "Id");
        }
    }
}
