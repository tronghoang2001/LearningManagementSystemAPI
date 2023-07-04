using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassDetails");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MySubject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySubject", x => new { x.SubjectId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_MySubject_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MySubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_DepartmentId",
                table: "Class",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MySubject_AccountId",
                table: "MySubject",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Department_DepartmentId",
                table: "Class",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Department_DepartmentId",
                table: "Class");

            migrationBuilder.DropTable(
                name: "MySubject");

            migrationBuilder.DropIndex(
                name: "IX_Class_DepartmentId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Class");

            migrationBuilder.CreateTable(
                name: "ClassDetails",
                columns: table => new
                {
                    ClassDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    DeparmentId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDetails", x => x.ClassDetailsId);
                    table.ForeignKey(
                        name: "FK_ClassDetails_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_ClassDetails_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_ClassDetails_Department_DeparmentId",
                        column: x => x.DeparmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_ClassDetails_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetails_AccountId",
                table: "ClassDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetails_ClassId",
                table: "ClassDetails",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetails_DeparmentId",
                table: "ClassDetails",
                column: "DeparmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDetails_SubjectId",
                table: "ClassDetails",
                column: "SubjectId");
        }
    }
}
