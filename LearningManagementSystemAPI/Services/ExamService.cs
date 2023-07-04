using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Exam> ApproveExamAsync(ApproveDTO approveDTO, int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return null;
            }
            _mapper.Map(approveDTO, exam);
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<List<ExamsDTO>> GetAllExamAsync(int? subjectId, int? lecturers, int? status)
        {
            var examsQuery = _context.Exams
                .Include(e => e.Subject)
                .ThenInclude(e => e.MySubjects)
                .ThenInclude(e => e.Account)
                 .Where(c => (!subjectId.HasValue || c.Subject.SubjectId == subjectId.Value) &&
                    (!lecturers.HasValue || c.Subject.MySubjects.Any(ms => ms.AccountId == lecturers.Value)) &&
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
            var exams = await examsQuery.ToListAsync();
            return exams;
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
