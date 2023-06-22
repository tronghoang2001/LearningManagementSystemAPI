using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("CollectTuition")]
    public class CollectTuition
    {
        [Key]
        public int CollectTuitionId { get; set; }
        public int TotalMoney { get; set; }
        public int Status { get; set; }
        public int Receivables { get; set; }
        public DateTime? CollectionDate { get; set; }
        public int TotalTime { get; set; }
        [MaxLength(100)]
        public string PaymentMethods { get; set; }
        public int? Surcharge { get; set; }
        public string? Note { get; set; }
        [MaxLength(20)]
        public string Semester { get; set; }
        [MaxLength(20)]
        public string ShoolYear { get; set; }
        public int DiscountId { get; set; }
        public int AccountId { get; set; }
        public int ExemptionsId { get; set; }
        public Discount Discount { get; set; }
        public Account Account { get; set; }
        public Exemptions Exemptions { get; set; }
        [JsonIgnore]
        public ICollection<Receipts> Receipts { get; set; }
    }
}
