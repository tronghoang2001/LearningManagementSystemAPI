using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Exemptions")]
    public class Exemptions
    {
        [Key]
        public int ExemptionsId { get; set; }
        [MaxLength(30)]
        public string Object { get; set; }
        public double Percent { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [JsonIgnore]
        public ICollection<CollectTuition> CollectTuitions { get; set; }
    }
}
