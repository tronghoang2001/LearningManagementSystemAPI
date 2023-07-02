using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Lesson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
