using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("TimeKeeping")]
    public class TimeKeeping
    {
        [Key]
        public int TimeKeepingId { get; set; }
        public int TotalDate { get; set; }
        public int ActualWorkDate { get; set; }
        public int TotalTime { get; set; }
        public int TeacherProfileId { get; set; }
        public TeacherProfile TeacherProfile { get; set; }
        [JsonIgnore]
        public ICollection<OnLeave> OnLeaves { get; set; }
    }
}
