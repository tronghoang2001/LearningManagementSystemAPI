using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("ClassDetails")]
    public class ClassDetails
    {
        [Key]
        public int ClassDetailsId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int AccountId { get; set; }
        public int DeparmentId { get; set; }
        public Class Class { get; set; }
        public Department Department { get; set; }
        public Subject Subject { get; set; }
        public Account Account { get; set; }
        [JsonIgnore]
        public ICollection<Exam> Exams { get; set; }
    }
}
