using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IExamService
    {
        public Task<List<ExamsDTO>> GetAllExamAsync(int? subjectId, int? lecturers, int? status);
        public Task<ExamDTO> GetExamByIdAsync(int id);
        public Task<Exam> ApproveExamAsync(ApproveDTO approveDTO, int id);
    }
}
