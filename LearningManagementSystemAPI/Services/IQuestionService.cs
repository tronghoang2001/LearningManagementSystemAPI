using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IQuestionService
    {
        public Task<Question> CreateQuestionAsync(CreateQuestionDTO questionDTO);
        public Task<List<QuestionDTO>> GetAllQuestionAsync();
    }
}
