using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata;

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

        public async Task<Subject> ApproveSubjectAsync(ApproveDTO subjectDTO, int id)
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
                .Include(s => s.MySubjects)
                .FirstOrDefaultAsync(p => p.SubjectId == id);

            if (subject != null)
            {
                var filePath = Path.Combine("Uploads\\Subject", subject.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.MySubjects.RemoveRange(subject.MySubjects);
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
                .Include(s => s.SubjectAssignments)
                    .ThenInclude(s => s.Class)
                    .ThenInclude(s => s.Department)
                .Include(s => s.Topics)
                    .ThenInclude(t => t.Lessons)
                        .ThenInclude(l => l.Resources)
                .FirstOrDefaultAsync(t => t.SubjectId == id);
            if(subject == null)
            {
                return null;
            }
            var subjectDTO = _mapper.Map<SubjectDetailsDTO>(subject);
            return subjectDTO;
        }

        public async Task<List<DocumentDTO>> GetDocumentsBySubjectIdAsync(int subjectId)
        {
            var subject = await GetSubjectByIdAsync(subjectId);

            if (subject == null)
            {
                return null;
            }

            var documents = new List<DocumentDTO>();

            foreach (var topic in subject.Topic_list)
            {
                foreach (var lesson in topic.Lesson)
                {
                    documents.Add(new DocumentDTO
                    {
                        FileName = lesson.FileName,
                        Type = "Bài giảng",
                        Lecturers = subject.Sender,
                        SentDate = lesson.SentDate.ToString("dd/MM/yyyy"),
                        Status = lesson.Status
                    });

                    foreach (var resource in lesson.Resources_list)
                    {
                        documents.Add(new DocumentDTO
                        {
                            FileName = resource.FileName,
                            Type = "Tài nguyên",
                            Lecturers = subject.Sender,
                            SentDate = resource.SentDate.ToString("dd/MM/yyyy"),
                            Status = resource.Status
                        });
                    }
                }
            }

            return documents;
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

        public async Task<List<DocumentDTO>> GetAllDocumentsAsync(int? subjectId, int? lecturers, int? status)
        {
            var documentsQuery = _context.Lessons
                .Include(l => l.Topic)
                    .ThenInclude(l => l.Subject)
                    .ThenInclude(l => l.MySubjects)
                    .ThenInclude(l => l.Account)
                .Include(l => l.Resources)
                .Where(l => (!subjectId.HasValue || l.Topic.SubjectId == subjectId.Value) &&
                            (!lecturers.HasValue || l.Topic.Subject.MySubjects.Any(ms => ms.AccountId == lecturers.Value)) &&
                            (!status.HasValue || l.Status == status.Value))
                .Select(l => new DocumentDTO
                {
                    FileName = l.FileName,
                    Type = "Bài giảng",
                    SubjectName = l.Topic.Subject.Name, 
                    Lecturers = l.Topic.Subject.Sender,
                    SentDate = l.SentDate.ToString("dd/MM/yyyy"),
                    Status = l.Status
                });

            var resourceDocumentsQuery = _context.Resources
                .Include(r => r.Lesson.Topic.Subject)
                .Where(r => (!subjectId.HasValue || r.Lesson.Topic.SubjectId == subjectId.Value) &&
                            (!lecturers.HasValue || r.Lesson.Topic.Subject.MySubjects.Any(ms => ms.AccountId == lecturers.Value)) &&
                            (!status.HasValue || r.Status == status.Value))
                .Select(r => new DocumentDTO
                {
                    FileName = r.FileName,
                    Type = "Tài nguyên",
                    SubjectName = r.Lesson.Topic.Subject.Name,
                    Lecturers = r.Lesson.Topic.Subject.Sender,
                    SentDate = r.SentDate.ToString("dd/MM/yyyy"),
                    Status = r.Status
                });

            var documents = await documentsQuery.ToListAsync();
            var resourceDocuments = await resourceDocumentsQuery.ToListAsync();

            documents.AddRange(resourceDocuments);
            return documents;
        }

        public async Task<SubjectAssignment> CreateSubjectAssignmentAsync(CreateSubjectAssignmentDTO subjectAssignmentDTO)
        {
            var assignment = _mapper.Map<SubjectAssignment>(subjectAssignmentDTO);
            await _context.SubjectAssignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<List<SubjectDTO>> GetSubjectByAccountIdAsync(int accountId)
        {
            var subjects = await _context.Subjects
                .Include(s => s.MySubjects)
                    .ThenInclude(ms => ms.Account)
                .Where(s => s.MySubjects.Any(ms => ms.Account.AccountId == accountId))
                .ToListAsync();
            var mySubjectDto = _mapper.Map<List<SubjectDTO>>(subjects);
            return mySubjectDto;
        }

        public async Task<FileStreamResult> DownloadSubjectFileAsync(int subjectId)
        {
            var subjectFile = await _context.Subjects.FindAsync(subjectId);
            if (subjectFile == null)
            {
                throw new Exception("File not found");
            }

            var filePath = Path.Combine("Uploads\\Subject", subjectFile.FileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = subjectFile.FileName
            };
        }
    }
}
