using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<QuestionBank> CreateEssayQuestionAsync(CreateEssayQuestionDTO essayQuestionDTO)
        {
            var question = _mapper.Map<QuestionBank>(essayQuestionDTO);
            question.CreateDate = DateTime.Now;
            question.UpdateDate = DateTime.Now;
            await _context.QuestionBanks.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Exam> CreateExamAsync(CreateExamDTO examDTO)
        {
            var exam = new Exam
            {
                Name = examDTO.Name,
                Method = examDTO.Method,
                Time = examDTO.Time,
                SubjectId = examDTO.SubjectId,
                Status = 0,
                CreateDate = DateTime.Now,
                ExamDetails = new List<ExamDetails>()
            };

            foreach (var questionId in examDTO.questionBanks)
            {
                var question = await _context.QuestionBanks.FindAsync(questionId);
                if (question != null)
                {
                    var examDetails = new ExamDetails
                    {
                        Exam = exam,
                        QuestionBank = question
                    };
                    exam.ExamDetails.Add(examDetails);
                }
            }

            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();

            return exam;
        }

        public async Task<QuestionBank> CreateQuestionAsync(CreateQuestionBankDTO questionBankDTO)
        {
            var question = _mapper.Map<QuestionBank>(questionBankDTO);
            question.CreateDate = DateTime.Now;
            question.UpdateDate = DateTime.Now;
            await _context.QuestionBanks.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.QuestionBanks.FirstOrDefaultAsync(c => c.QuestionId == id);

            if (question != null)
            {
                _context.QuestionBanks.Remove(question);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<FileStreamResult> DownloadExamFileAsync(int id)
        {
            var examFile = await _context.Exams.FindAsync(id);
            if (examFile == null)
            {
                throw new Exception("File not found");
            }

            var filePath = Path.Combine("Uploads\\Exam", examFile.FileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = examFile.FileName
            };
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

        public async Task<List<QuestionBankDTO>> GetAllQuestionAsync()
        {
            var questions = await _context.QuestionBanks.ToListAsync();
            return _mapper.Map<List<QuestionBankDTO>>(questions);
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

        public async Task<QuestionBankDetailsDTO> GetQuestionByIdAsync(int id)
        {
            var question = await _context.QuestionBanks.FirstOrDefaultAsync(t => t.QuestionId == id);
            if (question == null)
            {
                return null;
            }
            var questionBankDto = _mapper.Map<QuestionBankDetailsDTO>(question);
            return questionBankDto;
        }

        public async Task<QuestionBank> UpdateQuestionAsync(CreateQuestionBankDTO questionBankDTO, int id)
        {
            var question = await _context.QuestionBanks.FindAsync(id);
            if (question == null)
            {
                return null;
            }
            question.UpdateDate = DateTime.Now;
            _mapper.Map(questionBankDTO, question);
            _context.QuestionBanks.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Exam> UploadExamFileAsync(UploadExamFileDTO examFileDTO, IFormFile file)
        {
            var exam = _mapper.Map<Exam>(examFileDTO);
            if (file != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var filePath = Path.Combine("Uploads\\Exam", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                exam.Name = fileName;
                exam.FileName = fileName;
                exam.CreateDate = DateTime.Now;
                exam.Status = 0;
            }
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();

            return exam;
        }
    }
}
