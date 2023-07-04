using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("MySubject")]
    public class MySubject
    {
        public int SubjectId { get; set; }
        public int AccountId { get; set; }
        public Subject Subject { get; set; }
        public Account Account { get; set; }
    }
}
