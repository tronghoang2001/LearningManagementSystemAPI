using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateEssayQuestionDTO
    {
        [MaxLength(200)]
        public string Question { get; set; }
    }
}
