using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public SubjectService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Subject> ApproveSubjectAsync(ApproveSubjectDTO subjectDTO, int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return null;
            }
            _mapper.Map(subjectDTO, subject);
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> CreateSubjectAsync(CreateSubjectDTO subjectDTO, IFormFile file)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);
            var account = await _context.Accounts.FirstOrDefaultAsync(p => p.AccountId == subjectDTO.AccountId);
            
            if (file != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var filePath = Path.Combine("Uploads\\Subject", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                subject.Sender = account.Name;
                subject.SentDate = DateTime.Now;
                subject.FileName = fileName;
                subject.Status = 0;
            }
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.ClassDetails)
                .FirstOrDefaultAsync(p => p.SubjectId == id);

            if (subject != null)
            {
                var filePath = Path.Combine("Uploads\\Subject", subject.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.ClassDetails.RemoveRange(subject.ClassDetails);
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<SubjectDTO>> GetAllSubjectAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return _mapper.Map<List<SubjectDTO>>(subjects);
        }

        public async Task<SubjectDetailsDTO> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.Topics)
                    .ThenInclude(t => t.Lessons)
                        .ThenInclude(l => l.Resources)
                .FirstOrDefaultAsync(t => t.SubjectId == id);
            if(subject == null)
            {
                return null;
            }
            var tintucDto = _mapper.Map<SubjectDetailsDTO>(subject);
            return tintucDto;
        }

        public async Task<Subject> UpdateSubjectAsync(CreateSubjectDTO subjectDTO, int id, IFormFile file)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return null;
            }
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("Uploads\\Subject", subject.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var fileName = file.FileName;
                filePath = Path.Combine("Uploads\\Subject", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                subject.SentDate = DateTime.Now;
                subject.FileName = fileName;
                subject.Status = 0;
            }
            _mapper.Map(subjectDTO, subject);
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
    }
}
