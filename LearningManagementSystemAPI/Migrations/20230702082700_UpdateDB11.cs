using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exam_FileName",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_Name",
                table: "Exam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exam_FileName",
                table: "Exam",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Name",
                table: "Exam",
                column: "Name",
                unique: true);
        }
    }
}
