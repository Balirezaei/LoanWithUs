using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class supporterAcceptedRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedApplicantLoanRequest",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ConfirmedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedApplicantLoanRequest", x => new { x.SupporterId, x.Id });
                    table.ForeignKey(
                        name: "FK_AcceptedApplicantLoanRequest_Supporter_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "Supporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 22, 17, 9, 49, 113, DateTimeKind.Local).AddTicks(5994));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedApplicantLoanRequest");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 4, 21, 13, 18, 43, 527, DateTimeKind.Local).AddTicks(5534));
        }
    }
}
