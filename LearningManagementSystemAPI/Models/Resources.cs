using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Resources")]
    public class Resources
    {
        [Key]
        public int ResourcesId { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime SentDate { get; set; }
        public int Status { get; set; }
        [MaxLength(50)]
        public string? ApprovedBy { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
