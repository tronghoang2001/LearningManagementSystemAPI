using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class UploadExamFileDTO
    {
        [MaxLength(50)]
        public string Method { get; set; }
        public int Time { get; set; }
        public int SubjectId { get; set; }
    }
}
