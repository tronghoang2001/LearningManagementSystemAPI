using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Topic")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [JsonIgnore]
        public ICollection<Lesson> Lessons { get; set; }
    }
}
