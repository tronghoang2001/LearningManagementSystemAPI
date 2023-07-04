namespace LearningManagementSystemAPI.DTOs
{
    public class CreateNotificationDTO
    {
        public int AccountId { get; set; }
        public int? SubjectId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
