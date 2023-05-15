using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class LoanRequiredDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PenaltyFee",
                table: "LoanInstallment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueIdentity",
                table: "LoanInstallment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "DailyPenalty",
                table: "Loan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ApplicantLoanRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LoanRequiredDocument",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanWithUsFileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequiredDocument", x => new { x.LoanId, x.Id });
                    table.ForeignKey(
                        name: "FK_LoanRequiredDocument_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequiredDocument_LoanWithUsFile_LoanWithUsFileId",
                        column: x => x.LoanWithUsFileId,
                        principalTable: "LoanWithUsFile",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 14, 15, 9, 35, 698, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequiredDocument_LoanWithUsFileId",
                table: "LoanRequiredDocument",
                column: "LoanWithUsFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanRequiredDocument");

            migrationBuilder.DropColumn(
                name: "PenaltyFee",
                table: "LoanInstallment");

            migrationBuilder.DropColumn(
                name: "UniqueIdentity",
                table: "LoanInstallment");

            migrationBuilder.DropColumn(
                name: "DailyPenalty",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ApplicantLoanRequest");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 5, 9, 15, 50, 43, 743, DateTimeKind.Local).AddTicks(5832));
        }
    }
}
