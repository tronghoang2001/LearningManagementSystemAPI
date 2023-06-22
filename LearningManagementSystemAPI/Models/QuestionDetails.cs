using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("QuestionDetails")]
    public class QuestionDetails
    {
        [Key]
        public int QuestionDetailsId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int AccountId { get; set; }
        public Question Question { get; set; }
        public Answer? Answer { get; set; }
        public Account Account { get; set; }
    }
}
