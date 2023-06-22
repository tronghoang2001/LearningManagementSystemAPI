using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Context
{
    public class LmsContext : DbContext
    {
        public LmsContext(DbContextOptions<LmsContext> options) : base(options)
        {

        }
        #region DbSet
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Answer> Answers { get; set;}
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassDetails> ClassDetails { get; set; }
        public DbSet<CollectTuition> CollectTuitions { get; set; }
        public DbSet<ContractInsurance> ContractInsurances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamBank> ExamBanks { get; set; }
        public DbSet<ExamDetails> ExamDetails { get; set; }
        public DbSet<Exemptions> Exemptions { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<PrivateFiles> PrivateFiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<SalaryStatistics> SalaryStatistics { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectInformation> SubjectInformation { get; set; }
        public DbSet<SubjectTuition> SubjectTuitions { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<TeacherContract> TeacherContracts { get; set; }
        public DbSet<TeacherPosition> TeacherPositions { get; set; }
        public DbSet<TeacherProfile> TeacherProfiles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TimeKeeping> TimeKeepings { get; set; }
        public DbSet<OnLeave> OnLeaves { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasIndex(c => c.Code)
                .IsUnique();
            modelBuilder.Entity<Class>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<ClassDetails>()
                .HasOne(c => c.Class)
                .WithMany(ct => ct.ClassDetails)
                .HasForeignKey(c => c.ClassId);
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<ClassDetails>()
                .HasOne(c => c.Department)
                .WithMany(ct => ct.ClassDetails)
                .HasForeignKey(c => c.DeparmentId);
            modelBuilder.Entity<ClassDetails>()
                .HasOne(c => c.Account)
                .WithMany(ct => ct.ClassDetails)
                .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Subject>()
                .HasIndex(d => d.Code)
                .IsUnique();
            modelBuilder.Entity<Subject>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<ClassDetails>()
                .HasOne(c => c.Subject)
                .WithMany(ct => ct.ClassDetails)
                .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<SubjectInformation>()
                .HasOne(c => c.Subject)
                .WithMany(ct => ct.SubjectInformation)
                .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<Topic>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<Topic>()
                .HasOne(c => c.Subject)
                .WithMany(ct => ct.Topics)
                .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<Lesson>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<Lesson>()
               .HasOne(c => c.Topic)
               .WithMany(ct => ct.Lessons)
               .HasForeignKey(c => c.TopicId);
            modelBuilder.Entity<Resources>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<Resources>()
               .HasOne(c => c.Lesson)
               .WithMany(ct => ct.Resources)
               .HasForeignKey(c => c.LessonId);
            modelBuilder.Entity<SubjectTuition>()
               .HasOne(c => c.Subject)
               .WithMany(ct => ct.SubjectTuitions)
               .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<Exam>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<Exam>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<Exam>()
               .HasOne(c => c.ClassDetails)
               .WithMany(ct => ct.Exams)
               .HasForeignKey(c => c.ClassDetailsId);
            modelBuilder.Entity<ExamDetails>()
                .HasKey(k => new { k.ExamId, k.ExamBankId });
            modelBuilder.Entity<ExamDetails>()
               .HasOne(c => c.Exam)
               .WithMany(ct => ct.ExamDetails)
               .HasForeignKey(c => c.ExamId);
            modelBuilder.Entity<ExamDetails>()
               .HasOne(c => c.ExamBank)
               .WithMany(ct => ct.ExamDetails)
               .HasForeignKey(c => c.ExamBankId);
            modelBuilder.Entity<Account>()
               .HasOne(c => c.Role)
               .WithMany(ct => ct.Accounts)
               .HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<Role>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<Permission>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<PermissionRole>()
                .HasKey(k => new { k.RoleId, k.PermissionId });
            modelBuilder.Entity<PermissionRole>()
               .HasOne(c => c.Role)
               .WithMany(ct => ct.PermissionRoles)
               .HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<PermissionRole>()
               .HasOne(c => c.Permission)
               .WithMany(ct => ct.PermissionRoles)
               .HasForeignKey(c => c.PermissionId);
            modelBuilder.Entity<PrivateFiles>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<PrivateFiles>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.PrivateFiles)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Support>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.Supports)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<QuestionDetails>()
             .HasOne(c => c.Question)
             .WithMany(ct => ct.QuestionDetails)
             .HasForeignKey(c => c.QuestionId);
            modelBuilder.Entity<QuestionDetails>()
             .HasOne(c => c.Answer)
             .WithMany(ct => ct.QuestionDetails)
             .HasForeignKey(c => c.AnswerId);
            modelBuilder.Entity<QuestionDetails>()
             .HasOne(c => c.Account)
             .WithMany(ct => ct.QuestionDetails)
             .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Discount>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<Exemptions>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<CollectTuition>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.CollectTuitions)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<CollectTuition>()
              .HasOne(c => c.Discount)
              .WithMany(ct => ct.CollectTuitions)
              .HasForeignKey(c => c.DiscountId);
            modelBuilder.Entity<CollectTuition>()
              .HasOne(c => c.Exemptions)
              .WithMany(ct => ct.CollectTuitions)
              .HasForeignKey(c => c.ExemptionsId);
            modelBuilder.Entity<Receipts>()
              .HasOne(c => c.CollectTuition)
              .WithMany(ct => ct.Receipts)
              .HasForeignKey(c => c.CollectTuitionId);
            modelBuilder.Entity<Revenue>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<TeacherProfile>()
                .HasIndex(d => d.IdNumber)
                .IsUnique();
            modelBuilder.Entity<TeacherProfile>()
                .HasIndex(d => d.SocialInsurance)
                .IsUnique();
            modelBuilder.Entity<TeacherProfile>()
                .HasIndex(d => d.DecisionFile)
                .IsUnique();
            modelBuilder.Entity<TeacherPosition>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<TeacherProfile>()
              .HasOne(c => c.TeacherPosition)
              .WithMany(ct => ct.TeacherProfiles)
              .HasForeignKey(c => c.TeacherPositionId);
            modelBuilder.Entity<TeacherProfile>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.TeacherProfiles)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<TeacherContract>()
                .HasIndex(d => d.Number)
                .IsUnique();
            modelBuilder.Entity<TeacherContract>()
                .HasIndex(d => d.FileName)
                .IsUnique();
            modelBuilder.Entity<TeacherContract>()
              .HasOne(c => c.TeacherProfile)
              .WithMany(ct => ct.TeacherContracts)
              .HasForeignKey(c => c.TeacherProfileId);
            modelBuilder.Entity<TeacherContract>()
              .HasOne(c => c.Salary)
              .WithMany(ct => ct.TeacherContracts)
              .HasForeignKey(c => c.SalaryId);
            modelBuilder.Entity<Salary>()
               .HasIndex(d => d.FileName)
               .IsUnique();
            modelBuilder.Entity<Salary>()
              .HasOne(c => c.Rank)
              .WithMany(ct => ct.Salaries)
              .HasForeignKey(c => c.RankId);
            modelBuilder.Entity<Rank>()
               .HasIndex(d => d.Code)
               .IsUnique();
            modelBuilder.Entity<Rank>()
               .HasIndex(d => d.Name)
               .IsUnique();
            modelBuilder.Entity<Allowance>()
               .HasIndex(d => d.Code)
               .IsUnique();
            modelBuilder.Entity<Allowance>()
               .HasIndex(d => d.Name)
               .IsUnique();
            modelBuilder.Entity<Allowance>()
              .HasOne(c => c.TeacherProfile)
              .WithMany(ct => ct.Allowances)
              .HasForeignKey(c => c.TeacherProfileId);
            modelBuilder.Entity<Insurance>()
               .HasIndex(d => d.Name)
               .IsUnique();
            modelBuilder.Entity<ContractInsurance>()
                .HasKey(k => new { k.TeacherContractId, k.InsuranceId });
            modelBuilder.Entity<ContractInsurance>()
              .HasOne(c => c.TeacherContract)
              .WithMany(ct => ct.ContractInsurances)
              .HasForeignKey(c => c.TeacherContractId);
            modelBuilder.Entity<ContractInsurance>()
              .HasOne(c => c.Insurance)
              .WithMany(ct => ct.ContractInsurances)
              .HasForeignKey(c => c.InsuranceId);
            modelBuilder.Entity<SalaryStatistics>()
               .HasIndex(d => d.Code)
               .IsUnique();
            modelBuilder.Entity<SalaryStatistics>()
               .HasIndex(d => d.Name)
               .IsUnique();
            modelBuilder.Entity<TimeKeeping>()
              .HasOne(c => c.TeacherProfile)
              .WithMany(ct => ct.TimeKeepings)
              .HasForeignKey(c => c.TeacherProfileId);
            modelBuilder.Entity<OnLeave>()
              .HasOne(c => c.TimeKeeping)
              .WithMany(ct => ct.OnLeaves)
              .HasForeignKey(c => c.TimeKeepingId);
        }
    }
}
