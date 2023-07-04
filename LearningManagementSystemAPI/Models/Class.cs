using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [JsonIgnore]
        public ICollection<SubjectAssignment> SubjectAssignments { get; set; }
    }
}
