using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateRoleDTO
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public List<int> Permissions { get; set; }
    }
}
