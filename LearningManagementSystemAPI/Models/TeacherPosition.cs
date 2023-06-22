using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("TeacherPosition")]
    public class TeacherPosition
    {
        [Key]
        public int TeacherPositionId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime ApplicableDate { get; set; }
        [JsonIgnore]
        public ICollection<TeacherProfile> TeacherProfiles { get; set; }
    }
}
