using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("OnLeave")]
    public class OnLeave
    {
        [Key]
        public int OnLeaveId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [MaxLength(200)]
        public string Reason { get; set; }
        public int Status { get; set; }
        public int TimeKeepingId { get; set; }
        public TimeKeeping TimeKeeping { get; set; }
    }
}
