using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateSubjectDTO
    {
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
    }
}
