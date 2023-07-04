namespace LearningManagementSystemAPI.DTOs
{
    public class CreateAnswerDTO
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int AccountId { get; set; }
    }
}
