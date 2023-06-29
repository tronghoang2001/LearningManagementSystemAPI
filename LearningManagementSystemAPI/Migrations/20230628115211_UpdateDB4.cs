using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Account_AccountId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Class_ClassId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Department_DeparmentId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Subject_SubjectId",
                table: "ClassDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "ClassDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeparmentId",
                table: "ClassDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "ClassDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Account_AccountId",
                table: "ClassDetails",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Class_ClassId",
                table: "ClassDetails",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Department_DeparmentId",
                table: "ClassDetails",
                column: "DeparmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Subject_SubjectId",
                table: "ClassDetails",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Account_AccountId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Class_ClassId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Department_DeparmentId",
                table: "ClassDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassDetails_Subject_SubjectId",
                table: "ClassDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "ClassDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeparmentId",
                table: "ClassDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "ClassDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Account_AccountId",
                table: "ClassDetails",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Class_ClassId",
                table: "ClassDetails",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Department_DeparmentId",
                table: "ClassDetails",
                column: "DeparmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDetails_Subject_SubjectId",
                table: "ClassDetails",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
