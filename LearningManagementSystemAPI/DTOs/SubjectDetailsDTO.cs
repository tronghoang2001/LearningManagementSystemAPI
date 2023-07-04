using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class SubjectDetailsDTO
    {
        public int SubjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public List<TopicDTO> Topic_list { get; set; }
        public List<SubjectOverviewDTO> subjectOverview { get; set; }
    }
}
