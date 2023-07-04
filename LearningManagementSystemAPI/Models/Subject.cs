using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(50)]
        public string Sender { get; set; }
        public DateTime SentDate { get; set; }
        public int Status { get; set; }
        [JsonIgnore]
        public ICollection<MySubject> MySubjects { get; set; }
        [JsonIgnore]
        public ICollection<SubjectInformation> SubjectInformation { get; set; }
        [JsonIgnore]
        public ICollection<Topic> Topics { get; set; }
        [JsonIgnore]
        public ICollection<SubjectTuition> SubjectTuitions { get; set; }
        [JsonIgnore]
        public ICollection<Exam> Exams { get; set; }
        [JsonIgnore]
        public ICollection<Notification> Notifications { get; set; }
        [JsonIgnore]
        public ICollection<SubjectAssignment> SubjectAssignments { get; set; }
    }
}
