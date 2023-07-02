using LearningManagementSystemAPI.DTOs;

namespace LearningManagementSystemAPI.Services
{
    public interface IExamService
    {
        public Task<List<ExamDTO>> GetAllExamAsync(int? subjectId, string? lecturers, int? status);
    }
}
