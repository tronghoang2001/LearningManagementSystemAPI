using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IExamService
    {
        public Task<List<ExamsDTO>> GetAllExamAsync(int? subjectId, string? lecturers, int? status);
        public Task<ExamDTO> GetExamByIdAsync(int id);
    }
}
