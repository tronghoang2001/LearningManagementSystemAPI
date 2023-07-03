using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.DTOs
{
    public class ExamDTO
    {
        public string SubjectName { get; set; }
        public string Name { get; set; }
        public string Lecturers { get; set; }
        public int Time { get; set; }
        public string Method { get; set; }
        public string CreateDate { get; set; }
        public List<ExamDetailsDTO> Question_list { get; set; }
        public List<ExamAnswersDTO> Answer_list { get; set; }
    }
}
