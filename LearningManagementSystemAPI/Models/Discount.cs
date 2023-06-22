using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
        public int Value { get; set; }
        [MaxLength(50)]
        public string ApplyWith { get; set; }
        public int Status { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [JsonIgnore]
        public ICollection<CollectTuition> CollectTuitions { get; set; }
    }
}
