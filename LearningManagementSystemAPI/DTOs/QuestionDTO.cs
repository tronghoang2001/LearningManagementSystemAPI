namespace LearningManagementSystemAPI.DTOs
{
    public class QuestionDTO
    {
        public string Name { get; set; }
        public string CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<AnswerDTO> Answer_list { get; set; }
    }
}
