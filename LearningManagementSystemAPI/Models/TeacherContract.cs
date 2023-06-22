using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("TeacherContract")]
    public class TeacherContract
    {
        [Key]
        public int TeacherContractId { get; set; }
        [MaxLength(20)]
        public string Number { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public int Status { get; set; }
        [MaxLength(50)]
        public string ContractType { get; set; }
        public int SalaryId { get; set; }
        public int TeacherProfileId { get; set; }
        public Salary Salary { get; set; }
        public TeacherProfile TeacherProfile { get; set; }
        [JsonIgnore]
        public ICollection<ContractInsurance> ContractInsurances { get; set; }
    }
}
