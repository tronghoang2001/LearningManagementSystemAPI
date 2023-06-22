using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("SalaryStatistics")]
    public class SalaryStatistics
    {
        [Key]
        public int SalaryStatisticsId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Month { get; set; }
        public int Total { get; set; }
        public int Spent { get; set; }
        public int Remaining { get; set; }
        public int Status { get; set; }
    }
}
