using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ClassDetails_ClassDetailsId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamDetails_ExamBank_ExamBankId",
                table: "ExamDetails");

            migrationBuilder.DropTable(
                name: "ExamBank");

            migrationBuilder.RenameColumn(
                name: "ExamBankId",
                table: "ExamDetails",
                newName: "QuestionBankId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamDetails_ExamBankId",
                table: "ExamDetails",
                newName: "IX_ExamDetails_QuestionBankId");

            migrationBuilder.RenameColumn(
                name: "ClassDetailsId",
                table: "Exam",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_ClassDetailsId",
                table: "Exam",
                newName: "IX_Exam_SubjectId");

            migrationBuilder.CreateTable(
                name: "QuestionBank",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    A = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    B = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    C = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    D = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBank", x => x.QuestionId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Subject_SubjectId",
                table: "Exam",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamDetails_QuestionBank_QuestionBankId",
                table: "ExamDetails",
                column: "QuestionBankId",
                principalTable: "QuestionBank",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Subject_SubjectId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamDetails_QuestionBank_QuestionBankId",
                table: "ExamDetails");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.RenameColumn(
                name: "QuestionBankId",
                table: "ExamDetails",
                newName: "ExamBankId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamDetails_QuestionBankId",
                table: "ExamDetails",
                newName: "IX_ExamDetails_ExamBankId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Exam",
                newName: "ClassDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_SubjectId",
                table: "Exam",
                newName: "IX_Exam_ClassDetailsId");

            migrationBuilder.CreateTable(
                name: "ExamBank",
                columns: table => new
                {
                    ExamBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    B = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    C = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    D = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamBank", x => x.ExamBankId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ClassDetails_ClassDetailsId",
                table: "Exam",
                column: "ClassDetailsId",
                principalTable: "ClassDetails",
                principalColumn: "ClassDetailsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamDetails_ExamBank_ExamBankId",
                table: "ExamDetails",
                column: "ExamBankId",
                principalTable: "ExamBank",
                principalColumn: "ExamBankId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
