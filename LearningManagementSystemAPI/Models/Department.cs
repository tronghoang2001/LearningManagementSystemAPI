using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<ClassDetails>? ClassDetails { get; set; }
    }
}
