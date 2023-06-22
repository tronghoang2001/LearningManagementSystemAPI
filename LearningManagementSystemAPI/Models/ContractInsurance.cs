using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("ContractInsurance")]
    public class ContractInsurance
    {
        public int TeacherContractId { get; set; }
        public int InsuranceId { get; set; }
        public TeacherContract TeacherContract { get; set; }
        public Insurance Insurance { get; set; }
    }
}
