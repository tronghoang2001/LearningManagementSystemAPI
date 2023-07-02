using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("QuestionBank")]
    public class QuestionBank
    {
        [Key]
        public int QuestionId { get; set; }
        [MaxLength(200)]
        public string Question { get; set; }
        [MaxLength(100)]
        public string A { get; set; }
        [MaxLength(100)]
        public string B { get; set; }
        [MaxLength(100)]
        public string C { get; set; }
        [MaxLength(100)]
        public string D { get; set; }
        [MaxLength(1)]
        public string Answer { get; set; }
        [MaxLength(15)]
        public string Level { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [JsonIgnore]
        public ICollection<ExamDetails> ExamDetails { get; set; }
    }
}
