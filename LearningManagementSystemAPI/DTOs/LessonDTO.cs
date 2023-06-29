namespace LearningManagementSystemAPI.DTOs
{
    public class LessonDTO
    {
        public int LessonId { get; set; }
        public string FileName { get; set; }
        public List<ResourcesDTO> Resources_list { get; set; }
    }
}
