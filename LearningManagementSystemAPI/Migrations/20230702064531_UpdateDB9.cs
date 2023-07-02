using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Lesson");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Lesson");

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Lesson",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
