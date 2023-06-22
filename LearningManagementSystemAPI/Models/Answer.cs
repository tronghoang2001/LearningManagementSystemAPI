using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public ICollection<QuestionDetails> QuestionDetails { get; set; }
    }
}
