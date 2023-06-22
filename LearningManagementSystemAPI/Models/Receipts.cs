using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Receipts")]
    public class Receipts
    {
        [Key]
        public int ReceiptsId { get; set; }
        public int TotalTime { get; set; }
        public int CollectTuitionId { get; set; }
        public CollectTuition CollectTuition { get; set; }
    }
}
