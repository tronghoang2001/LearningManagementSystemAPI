using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Insurance")]
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Percent { get; set; }
        [JsonIgnore]
        public ICollection<ContractInsurance> ContractInsurances { get; set; }
    }
}
