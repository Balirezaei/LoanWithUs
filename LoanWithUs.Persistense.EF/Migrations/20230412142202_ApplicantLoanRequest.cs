using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class ApplicantLoanRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantLoanLadder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanLadderFrameId = table.Column<int>(type: "int", nullable: false),
                    LoanLaddrFrameId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantLoanLadder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantLoanLadder_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantLoanLadder_LoanLadderFrames_LoanLadderFrameId",
                        column: x => x.LoanLadderFrameId,
                        principalTable: "LoanLadderFrames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantLoanRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastState = table.Column<int>(type: "int", nullable: false),
                    LoanLadderFrameId = table.Column<int>(type: "int", nullable: false),
                    InstallmentsCount = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    SupporterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantLoanRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantLoanRequest_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantLoanRequest_LoanLadderFrames_LoanLadderFrameId",
                        column: x => x.LoanLadderFrameId,
                        principalTable: "LoanLadderFrames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantLoanRequest_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantLoanRequestFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicantLoanRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantLoanRequestFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantLoanRequestFlow_ApplicantLoanRequest_ApplicantLoanRequestId",
                        column: x => x.ApplicantLoanRequestId,
                        principalTable: "ApplicantLoanRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 12, 17, 52, 2, 347, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanLadder_ApplicantId",
                table: "ApplicantLoanLadder",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanLadder_LoanLadderFrameId",
                table: "ApplicantLoanLadder",
                column: "LoanLadderFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanRequest_ApplicantId",
                table: "ApplicantLoanRequest",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanRequest_LoanLadderFrameId",
                table: "ApplicantLoanRequest",
                column: "LoanLadderFrameId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanRequest_SupporterId",
                table: "ApplicantLoanRequest",
                column: "SupporterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantLoanRequestFlow_ApplicantLoanRequestId",
                table: "ApplicantLoanRequestFlow",
                column: "ApplicantLoanRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantLoanLadder");

            migrationBuilder.DropTable(
                name: "ApplicantLoanRequestFlow");

            migrationBuilder.DropTable(
                name: "ApplicantLoanRequest");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 12, 12, 59, 47, 232, DateTimeKind.Local).AddTicks(8665));
        }
    }
}
