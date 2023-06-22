using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime SentDate { get; set; }
        public int Status { get; set; }
        [MaxLength(50)]
        public string ApprovedBy { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        [JsonIgnore]
        public ICollection<Resources> Resources { get; set; }
    }
}
