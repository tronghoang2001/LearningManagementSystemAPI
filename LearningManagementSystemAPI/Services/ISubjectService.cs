using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface ISubjectService
    {
        public Task<List<SubjectDTO>> GetAllSubjectAsync();
        public Task<Subject> CreateSubjectAsync(CreateSubjectDTO subjectDTO);
        public Task<Subject> UpdateSubjectAsync(CreateSubjectDTO subjectDTO, int id);
        public Task<bool> DeleteSubjectAsync(int id);
    }
}
