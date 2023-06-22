using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("ExamDetails")]
    public class ExamDetails
    {
        public int ExamId { get; set; }
        public int ExamBankId { get; set; }
        public Exam Exam { get; set; }
        public ExamBank ExamBank { get; set; }

    }
}
