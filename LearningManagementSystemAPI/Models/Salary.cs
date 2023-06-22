using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public double WageRank { get; set; }
        public double CoefficientsSalary { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime ApplicableDate { get; set; }
        public int BasicSalary { get; set; }
        public int RankId { get; set; }
        public Rank Rank { get; set; }
        [JsonIgnore]
        public ICollection<TeacherContract> TeacherContracts { get; set; }
    }
}
