namespace LearningManagementSystemAPI.DTOs
{
    public class ExamDTO
    {
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string SubjectName { get; set; }
        public string Method { get; set; }
        public int Time { get; set; }
        public string Lecturers { get; set; }
        public string CreateDate { get; set; }
        public int Status { get; set; }
    }
}
