using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class UpdateTopicDTO
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
