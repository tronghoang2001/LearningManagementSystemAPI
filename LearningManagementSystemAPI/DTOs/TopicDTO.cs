
namespace LearningManagementSystemAPI.DTOs
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public List<LessonDTO> Lesson { get; set; }
    }
}
