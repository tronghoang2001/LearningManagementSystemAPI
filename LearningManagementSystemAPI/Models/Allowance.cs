using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Allowance")]
    public class Allowance
    {
        [Key]
        public int AllowanceId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Value { get; set; }
        [MaxLength(20)]
        public string ValueType { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        [MaxLength(50)]
        public string BasedOn { get; set; }
        public int TeacherProfileId { get; set; }
        public TeacherProfile TeacherProfile { get; set; }
    }
}
