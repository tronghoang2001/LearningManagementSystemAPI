using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("PrivatesFile")]
    public class PrivateFiles
    {
        [Key]
        public int PrivateFilesId { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public double Size { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
