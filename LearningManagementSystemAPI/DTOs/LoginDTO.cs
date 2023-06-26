using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class LoginDTO
    {
        [Required]
        public int RoleId { get; set; }
        [Required, EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
