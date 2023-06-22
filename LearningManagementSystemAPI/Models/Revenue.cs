using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Revenue")]
    public class Revenue
    {
        [Key]
        public int RevenueId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string According { get; set; }
        [MaxLength(20)]
        public string Method { get; set; }
        public int Money { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
        public int Time { get; set; }
    }
}
