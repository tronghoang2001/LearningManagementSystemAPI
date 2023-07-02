using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(50)]
        public string Method { get; set; }
        public int Time { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [JsonIgnore]
        public ICollection<ExamDetails> ExamDetails { get; set; }
    }
}
