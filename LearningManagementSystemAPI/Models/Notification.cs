using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public int AccountId { get; set; }
        public int? SubjectId { get; set; }
        public Account Account { get; set; }
        public Subject? Subject { get; set; }
        [MaxLength(200)]
        public string? Title { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsRead { get; set; }
    }
}
