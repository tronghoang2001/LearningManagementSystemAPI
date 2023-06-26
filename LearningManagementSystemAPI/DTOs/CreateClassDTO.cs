using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateClassDTO
    {
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
