using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreatePermissionDTO
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
    }
}
