using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class SupporterCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupporterCredit",
                columns: table => new
                {
                    SupporterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Money_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupporterCredit", x => x.SupporterId);
                    table.ForeignKey(
                        name: "FK_SupporterCredit_Supporter_SupporterId",
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
                value: new DateTime(2023, 2, 28, 17, 19, 42, 12, DateTimeKind.Local).AddTicks(9223));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupporterCredit");

            migrationBuilder.UpdateData(
                table: "Administrator",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationDate",
                value: new DateTime(2023, 2, 16, 0, 21, 38, 775, DateTimeKind.Local).AddTicks(9177));
        }
    }
}
