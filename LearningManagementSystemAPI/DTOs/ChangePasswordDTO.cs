using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        [MaxLength(100)]
        public string CurrentPassword { get; set; }
        [Required]
        [MaxLength(100)]
        public string NewPassword { get; set; }
        [Required]
        [MaxLength(100)]
        public string ConfirmPassword { get; set; }
    }
}
