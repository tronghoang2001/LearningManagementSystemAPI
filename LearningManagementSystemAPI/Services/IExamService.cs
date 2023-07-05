using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Services
{
    public interface IExamService
    {
        public Task<List<ExamsDTO>> GetAllExamAsync(int? subjectId, int? lecturers, int? status);
        public Task<ExamDTO> GetExamByIdAsync(int id);
        public Task<Exam> ApproveExamAsync(ApproveDTO approveDTO, int id);
        public Task<Exam> CreateExamAsync(CreateExamDTO examDTO);
        public Task<QuestionBank> CreateQuestionAsync(CreateQuestionBankDTO questionBankDTO);
        public Task<QuestionBank> CreateEssayQuestionAsync(CreateEssayQuestionDTO essayQuestionDTO);
        public Task<Exam> UploadExamFileAsync(UploadExamFileDTO examFileDTO, IFormFile file);
        public Task<List<QuestionBankDTO>> GetAllQuestionAsync();
        public Task<QuestionBankDetailsDTO> GetQuestionByIdAsync(int id);
        public Task<QuestionBank> UpdateQuestionAsync(CreateQuestionBankDTO questionBankDTO, int id);
        public Task<bool> DeleteQuestionAsync(int id);
        public Task<FileStreamResult> DownloadExamFileAsync(int id);
    }
}
