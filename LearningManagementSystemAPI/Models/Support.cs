using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Support")]
    public class Support
    {
        [Key]
        public int SupportId { get; set; }
        public string Content { get; set; }
        public string? Reply { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
