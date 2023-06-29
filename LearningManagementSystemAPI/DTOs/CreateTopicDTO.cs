using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateTopicDTO
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
