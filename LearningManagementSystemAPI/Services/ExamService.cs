using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LearningManagementSystemAPI.Services
{
    public class ExamService : IExamService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public ExamService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ExamsDTO>> GetAllExamAsync(int? subjectId, string? lecturers, int? status)
        {
            var documentsQuery = _context.Exams
                .Include(e => e.Subject)
                .Where(c => (!subjectId.HasValue || c.Subject.SubjectId == subjectId.Value) &&
                            (string.IsNullOrEmpty(lecturers) || c.Subject.Sender == lecturers) &&
                            (!status.HasValue || c.Status == status.Value))
                .Select(e => new ExamsDTO
                {
                    FileName = e.FileName,
                    SubjectName = e.Subject.Name,
                    Method = e.Method,
                    Time = e.Time,
                    Lecturers = e.Subject.Sender,
                    CreateDate = e.CreateDate.ToString("dd/MM/yyyy, hh:mm tt"),
                    Status = e.Status
                });
            var documents = await documentsQuery.ToListAsync();
            return documents;
        }

        public async Task<ExamDTO> GetExamByIdAsync(int id)
        {
            var exam = await _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.ExamDetails)
                    .ThenInclude(e => e.QuestionBank)
                .FirstOrDefaultAsync(e => e.ExamId == id);
            if (exam == null)
            {
                return null;
            }
            var examDTO = _mapper.Map<ExamDTO>(exam);
            return examDTO;
        }
    }
}
