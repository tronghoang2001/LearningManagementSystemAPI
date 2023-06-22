using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public Boolean IsAnswer { get; set; }
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public ICollection<QuestionDetails> QuestionDetails { get; set; }
    }
}
