using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("SubjectTuition")]
    public class SubjectTuition
    {
        [Key]
        public int SubjectTuitionId { get; set; }
        public int Time { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
        public double CollectionRates { get; set; }
        public int Total { get; set; }
        public int Status { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
