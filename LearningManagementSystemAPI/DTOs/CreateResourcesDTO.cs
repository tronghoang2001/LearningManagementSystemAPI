using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateResourcesDTO
    {
        public int AccountId { get; set; }
        public int LessonId { get; set; }
    }
}
