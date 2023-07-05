using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateExamDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Method { get; set; }
        public int Time { get; set; }
        public int SubjectId { get; set; }
        public List<int> questionBanks { get; set; }
    }
}
