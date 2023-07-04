using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IAnswerService
    {
        public Task<Answer> CreateAnswerAsync(CreateAnswerDTO answerDTO);
    }
}
