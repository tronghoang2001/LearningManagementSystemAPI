using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface ISubjectService
    {
        public Task<List<SubjectDTO>> GetAllSubjectAsync();
        public Task<SubjectDetailsDTO> GetSubjectByIdAsync(int id);
        public Task<Subject> CreateSubjectAsync(CreateSubjectDTO subjectDTO, IFormFile file);
        public Task<Subject> UpdateSubjectAsync(CreateSubjectDTO subjectDTO, int id, IFormFile file);
        public Task<bool> DeleteSubjectAsync(int id);
        public Task<Subject> ApproveSubjectAsync(ApproveSubjectDTO subjectDTO, int id);
    }
}
