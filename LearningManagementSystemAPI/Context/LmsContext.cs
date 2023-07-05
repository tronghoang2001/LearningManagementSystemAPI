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
        public DbSet<Answer> Answers { get; set;}
        public DbSet<Class> Classes { get; set; }
        public DbSet<MySubject> MySubjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<ExamDetails> ExamDetails { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<PrivateFiles> PrivateFiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasIndex(c => c.Code)
                .IsUnique();
            modelBuilder.Entity<Class>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Department)
                .WithMany(ct => ct.Classes)
                .HasForeignKey(c => c.DepartmentId);
            modelBuilder.Entity<MySubject>()
                .HasKey(k => new { k.SubjectId, k.AccountId });
            modelBuilder.Entity<MySubject>()
                .HasOne(c => c.Account)
                .WithMany(ct => ct.MySubjects)
                .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Subject>()
                .HasIndex(d => d.Code)
                .IsUnique();
            modelBuilder.Entity<Subject>()
                .HasIndex(d => d.Name)
                .IsUnique();
            modelBuilder.Entity<MySubject>()
                .HasOne(c => c.Subject)
                .WithMany(ct => ct.MySubjects)
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
            modelBuilder.Entity<Exam>()
               .HasOne(c => c.Subject)
               .WithMany(ct => ct.Exams)
               .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<ExamDetails>()
                .HasKey(k => new { k.ExamId, k.QuestionBankId });
            modelBuilder.Entity<ExamDetails>()
               .HasOne(c => c.Exam)
               .WithMany(ct => ct.ExamDetails)
               .HasForeignKey(c => c.ExamId);
            modelBuilder.Entity<ExamDetails>()
               .HasOne(c => c.QuestionBank)
               .WithMany(ct => ct.ExamDetails)
               .HasForeignKey(c => c.QuestionBankId);
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
            modelBuilder.Entity<Answer>()
             .HasOne(c => c.Question)
             .WithMany(ct => ct.Answers)
             .HasForeignKey(c => c.QuestionId);
            modelBuilder.Entity<Answer>()
             .HasOne(c => c.Account)
             .WithMany(ct => ct.Answers)
             .HasForeignKey(c => c.AccountId);     
            modelBuilder.Entity<Notification>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.Notifications)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Notification>()
              .HasOne(c => c.Subject)
              .WithMany(ct => ct.Notifications)
              .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<SubjectAssignment>()
                .HasKey(k => new { k.SubjectId, k.ClassId });
            modelBuilder.Entity<SubjectAssignment>()
              .HasOne(c => c.Subject)
              .WithMany(ct => ct.SubjectAssignments)
              .HasForeignKey(c => c.SubjectId);
            modelBuilder.Entity<SubjectAssignment>()
              .HasOne(c => c.Class)
              .WithMany(ct => ct.SubjectAssignments)
              .HasForeignKey(c => c.ClassId);
            modelBuilder.Entity<Question>()
              .HasOne(c => c.Account)
              .WithMany(ct => ct.Questions)
              .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Question>()
              .HasOne(c => c.Subject)
              .WithMany(ct => ct.Questions)
              .HasForeignKey(c => c.SubjectId);
        }
    }
}
