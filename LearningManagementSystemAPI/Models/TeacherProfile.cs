using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("TeacherProfile")]
    public class TeacherProfile
    {
        [Key]
        public int TeacherProfileId { get; set; }
        [MaxLength(20)]
        public string IdNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        [MaxLength(200)]
        public string PlaceOfIssue { get; set; }
        [MaxLength(20)]
        public string? SocialInsurance { get; set; }
        [MaxLength(50)]
        public string QualificationLevel { get; set; }
        [MaxLength(100)]
        public string DecisionFile { get; set; }
        public DateTime JoinDate { get; set; }
        public int Status { get; set; }
        public DateTime ApplicableDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TeacherPositionId { get; set; }
        public int AccountId { get; set; }
        public TeacherPosition TeacherPosition { get; set; }
        public Account Account { get; set; }
        [JsonIgnore]
        public ICollection<TeacherContract> TeacherContracts { get; set; }
        [JsonIgnore]
        public ICollection<Allowance> Allowances { get; set; }
        [JsonIgnore]
        public ICollection<TimeKeeping> TimeKeepings { get; set; }
    }
}
