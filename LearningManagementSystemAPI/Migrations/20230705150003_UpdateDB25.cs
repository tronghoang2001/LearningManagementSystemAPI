using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystemAPI.Migrations
{
    public partial class UpdateDB25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Account_AccountId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "ContractInsurance");

            migrationBuilder.DropTable(
                name: "OnLeave");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropTable(
                name: "SalaryStatistics");

            migrationBuilder.DropTable(
                name: "SubjectInformation");

            migrationBuilder.DropTable(
                name: "SubjectTuition");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "TeacherContract");

            migrationBuilder.DropTable(
                name: "TimeKeeping");

            migrationBuilder.DropTable(
                name: "CollectTuition");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "TeacherProfile");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Exemptions");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "TeacherPosition");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Account_AccountId",
                table: "Question",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Account_AccountId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyWith = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Exemptions",
                columns: table => new
                {
                    ExemptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Object = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemptions", x => x.ExemptionsId);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.RankId);
                });

            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    RevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    According = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.RevenueId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStatistics",
                columns: table => new
                {
                    SalaryStatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remaining = table.Column<int>(type: "int", nullable: false),
                    Spent = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStatistics", x => x.SalaryStatisticsId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectInformation",
                columns: table => new
                {
                    InformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectInformation", x => x.InformationId);
                    table.ForeignKey(
                        name: "FK_SubjectInformation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTuition",
                columns: table => new
                {
                    SubjectTuitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CollectionRates = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTuition", x => x.SubjectTuitionId);
                    table.ForeignKey(
                        name: "FK_SubjectTuition_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPosition",
                columns: table => new
                {
                    TeacherPositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPosition", x => x.TeacherPositionId);
                });

            migrationBuilder.CreateTable(
                name: "CollectTuition",
                columns: table => new
                {
                    CollectTuitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ExemptionsId = table.Column<int>(type: "int", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethods = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Receivables = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShoolYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Surcharge = table.Column<int>(type: "int", nullable: true),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectTuition", x => x.CollectTuitionId);
                    table.ForeignKey(
                        name: "FK_CollectTuition_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectTuition_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectTuition_Exemptions_ExemptionsId",
                        column: x => x.ExemptionsId,
                        principalTable: "Exemptions",
                        principalColumn: "ExemptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasicSalary = table.Column<int>(type: "int", nullable: false),
                    CoefficientsSalary = table.Column<double>(type: "float", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WageRank = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salary_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Rank",
                        principalColumn: "RankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherProfile",
                columns: table => new
                {
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TeacherPositionId = table.Column<int>(type: "int", nullable: false),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecisionFile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QualificationLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SocialInsurance = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProfile", x => x.TeacherProfileId);
                    table.ForeignKey(
                        name: "FK_TeacherProfile_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherProfile_TeacherPosition_TeacherPositionId",
                        column: x => x.TeacherPositionId,
                        principalTable: "TeacherPosition",
                        principalColumn: "TeacherPositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectTuitionId = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptsId);
                    table.ForeignKey(
                        name: "FK_Receipts_CollectTuition_CollectTuitionId",
                        column: x => x.CollectTuitionId,
                        principalTable: "CollectTuition",
                        principalColumn: "CollectTuitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    AllowanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false),
                    BasedOn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ValueType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.AllowanceId);
                    table.ForeignKey(
                        name: "FK_Allowance_TeacherProfile_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfile",
                        principalColumn: "TeacherProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherContract",
                columns: table => new
                {
                    TeacherContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherContract", x => x.TeacherContractId);
                    table.ForeignKey(
                        name: "FK_TeacherContract_Salary_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salary",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherContract_TeacherProfile_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfile",
                        principalColumn: "TeacherProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeKeeping",
                columns: table => new
                {
                    TimeKeepingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false),
                    ActualWorkDate = table.Column<int>(type: "int", nullable: false),
                    TotalDate = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeKeeping", x => x.TimeKeepingId);
                    table.ForeignKey(
                        name: "FK_TimeKeeping_TeacherProfile_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfile",
                        principalColumn: "TeacherProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractInsurance",
                columns: table => new
                {
                    TeacherContractId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractInsurance", x => new { x.TeacherContractId, x.InsuranceId });
                    table.ForeignKey(
                        name: "FK_ContractInsurance_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractInsurance_TeacherContract_TeacherContractId",
                        column: x => x.TeacherContractId,
                        principalTable: "TeacherContract",
                        principalColumn: "TeacherContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnLeave",
                columns: table => new
                {
                    OnLeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeKeepingId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnLeave", x => x.OnLeaveId);
                    table.ForeignKey(
                        name: "FK_OnLeave_TimeKeeping_TimeKeepingId",
                        column: x => x.TimeKeepingId,
                        principalTable: "TimeKeeping",
                        principalColumn: "TimeKeepingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_Code",
                table: "Allowance",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_Name",
                table: "Allowance",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allowance_TeacherProfileId",
                table: "Allowance",
                column: "TeacherProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectTuition_AccountId",
                table: "CollectTuition",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectTuition_DiscountId",
                table: "CollectTuition",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectTuition_ExemptionsId",
                table: "CollectTuition",
                column: "ExemptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractInsurance_InsuranceId",
                table: "ContractInsurance",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Name",
                table: "Discount",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exemptions_FileName",
                table: "Exemptions",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_Name",
                table: "Insurance",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnLeave_TimeKeepingId",
                table: "OnLeave",
                column: "TimeKeepingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rank_Code",
                table: "Rank",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rank_Name",
                table: "Rank",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CollectTuitionId",
                table: "Receipts",
                column: "CollectTuitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_Name",
                table: "Revenue",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_FileName",
                table: "Salary",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_RankId",
                table: "Salary",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatistics_Code",
                table: "SalaryStatistics",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStatistics_Name",
                table: "SalaryStatistics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInformation_SubjectId",
                table: "SubjectInformation",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTuition_SubjectId",
                table: "SubjectTuition",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContract_FileName",
                table: "TeacherContract",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContract_Number",
                table: "TeacherContract",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContract_SalaryId",
                table: "TeacherContract",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContract_TeacherProfileId",
                table: "TeacherContract",
                column: "TeacherProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPosition_Name",
                table: "TeacherPosition",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfile_AccountId",
                table: "TeacherProfile",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfile_DecisionFile",
                table: "TeacherProfile",
                column: "DecisionFile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfile_IdNumber",
                table: "TeacherProfile",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfile_SocialInsurance",
                table: "TeacherProfile",
                column: "SocialInsurance",
                unique: true,
                filter: "[SocialInsurance] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfile_TeacherPositionId",
                table: "TeacherProfile",
                column: "TeacherPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeKeeping_TeacherProfileId",
                table: "TimeKeeping",
                column: "TeacherProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Account_AccountId",
                table: "Question",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
