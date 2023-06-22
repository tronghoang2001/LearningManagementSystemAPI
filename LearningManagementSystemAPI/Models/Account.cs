using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Boolean Gender { get; set; }
        [MaxLength(100)]
        public string Avatar { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(200)]
        public string? ResetToken { get; set; }
        public int Status { get; set; }
        [MaxLength(30)]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public ICollection<ClassDetails> ClassDetails { get; set; }
        [JsonIgnore]
        public ICollection<PrivateFiles> PrivateFiles { get; set; }
        [JsonIgnore]
        public ICollection<Support> Supports { get; set; }
        [JsonIgnore]
        public ICollection<QuestionDetails> QuestionDetails { get; set; }
        [JsonIgnore]
        public ICollection<CollectTuition> CollectTuitions { get; set; }
        [JsonIgnore]
        public ICollection<TeacherProfile> TeacherProfiles { get; set; }
    }
}
