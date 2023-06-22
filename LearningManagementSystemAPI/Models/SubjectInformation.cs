using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Models
{
    [Table("SubjectInformation")]
    public class SubjectInformation
    {
        [Key]
        public int InformationId { get; set; }
        [MaxLength(100)]    
        public string Title { get; set; }
        public string Content { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
