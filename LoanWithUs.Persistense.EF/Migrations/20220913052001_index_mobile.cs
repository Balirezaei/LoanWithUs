using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    public partial class index_mobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applicant_MobileNumber",
                table: "Applicant",
                column: "MobileNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applicant_MobileNumber",
                table: "Applicant");
        }
    }
}
