using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface ITopicService
    {
        public Task<Topic> CreateTopicAsync(CreateTopicDTO topicDTO);
        public Task<Topic> UpdateTopicAsync(UpdateTopicDTO topicDTO, int id);
        public Task<bool> DeleteTopicAsync(int id);
    }
}
