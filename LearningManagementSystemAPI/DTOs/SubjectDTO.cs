using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class SubjectDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public DateTime SentDate { get; set; }
        public int Status { get; set; }
    }
}
