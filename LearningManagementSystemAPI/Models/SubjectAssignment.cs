using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("SubjectAssignment")]
    public class SubjectAssignment
    {
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public Subject Subject { get; set; }
        public Class Class { get; set; }
    }
}
