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
        public int? AccountId { get; set; }
        public int? SubjectId { get; set; }
        public Account? Account { get; set; }
        public Subject? Subject { get; set; }
        [JsonIgnore]
        public ICollection<Answer> Answers { get; set; }
    }
}
