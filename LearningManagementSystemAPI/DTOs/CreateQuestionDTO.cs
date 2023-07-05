using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateQuestionDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }
        public int SubjectId { get; set; }
    }
}
