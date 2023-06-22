using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Status { get; set; }
        [JsonIgnore]
        public ICollection<Salary> Salaries { get; set; }
    }
}
