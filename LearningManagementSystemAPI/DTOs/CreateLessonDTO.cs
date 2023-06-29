using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateLessonDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public int TopicId { get; set; }
    }
}
