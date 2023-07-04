using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateSupportDTO
    {
        [Required]
        public string Content { get; set; }
        public int AccountId { get; set; }
    }
}
