using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using System.Reflection.Metadata;

namespace LearningManagementSystemAPI.Services
{
    public interface ISubjectService
    {
        public Task<List<SubjectDTO>> GetAllSubjectAsync();
        public Task<SubjectDetailsDTO> GetSubjectByIdAsync(int id);
        public Task<List<DocumentDTO>> GetDocumentsBySubjectIdAsync(int subjectId);
        public Task<List<DocumentDTO>> GetAllDocumentsAsync(int? subjectId, int? lecturers, int? status);
        public Task<Subject> CreateSubjectAsync(CreateSubjectDTO subjectDTO, IFormFile file);
        public Task<Subject> UpdateSubjectAsync(CreateSubjectDTO subjectDTO, int id, IFormFile file);
        public Task<bool> DeleteSubjectAsync(int id);
        public Task<Subject> ApproveSubjectAsync(ApproveDTO subjectDTO, int id);
        public Task<SubjectAssignment> CreateSubjectAssignmentAsync(CreateSubjectAssignmentDTO subjectAssignmentDTO);
    }
}
