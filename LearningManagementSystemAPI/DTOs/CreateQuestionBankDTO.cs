using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateQuestionBankDTO
    {
        [MaxLength(200)]
        public string Question { get; set; }
        [MaxLength(100)]
        public string A { get; set; }
        [MaxLength(100)]
        public string B { get; set; }
        [MaxLength(100)]
        public string C { get; set; }
        [MaxLength(100)]
        public string D { get; set; }
        [MaxLength(1)]
        public string Answer { get; set; }
        [MaxLength(15)]
        public string Level { get; set; }
    }
}
