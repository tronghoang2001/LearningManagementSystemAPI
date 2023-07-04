using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssignments_Class_ClassId",
                table: "SubjectAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssignments_Subject_SubjectId",
                table: "SubjectAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectAssignments",
                table: "SubjectAssignments");

            migrationBuilder.RenameTable(
                name: "SubjectAssignments",
                newName: "SubjectAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectAssignments_ClassId",
                table: "SubjectAssignment",
                newName: "IX_SubjectAssignment_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectAssignment",
                table: "SubjectAssignment",
                columns: new[] { "SubjectId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssignment_Class_ClassId",
                table: "SubjectAssignment",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssignment_Subject_SubjectId",
                table: "SubjectAssignment",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssignment_Class_ClassId",
                table: "SubjectAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssignment_Subject_SubjectId",
                table: "SubjectAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectAssignment",
                table: "SubjectAssignment");

            migrationBuilder.RenameTable(
                name: "SubjectAssignment",
                newName: "SubjectAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectAssignment_ClassId",
                table: "SubjectAssignments",
                newName: "IX_SubjectAssignments_ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectAssignments",
                table: "SubjectAssignments",
                columns: new[] { "SubjectId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssignments_Class_ClassId",
                table: "SubjectAssignments",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssignments_Subject_SubjectId",
                table: "SubjectAssignments",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
