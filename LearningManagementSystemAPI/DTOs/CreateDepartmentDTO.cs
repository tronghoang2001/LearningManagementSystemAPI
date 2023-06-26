using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateDepartmentDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
