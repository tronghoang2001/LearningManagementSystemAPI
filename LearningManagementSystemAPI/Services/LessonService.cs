using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LearningManagementSystemAPI.Services
{
    public class LessonService : ILessionService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public LessonService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Lesson> ApproveLessonAsync(ApproveDTO approveDTO, int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return null;
            }
            _mapper.Map(approveDTO, lesson);
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> CreateLessonAsync(CreateLessonDTO lessonDTO, IFormFile file)
        {
            var lesson = _mapper.Map<Lesson>(lessonDTO);

            if (file != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var filePath = Path.Combine("Uploads\\Lesson", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                lesson.SentDate = DateTime.Now;
                lesson.FileName = fileName;
                lesson.Status = 0;
            }
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();

            return lesson;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(p => p.LessonId == id);

            if (lesson != null)
            {
                var filePath = Path.Combine("Uploads\\Lesson", lesson.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<FileStreamResult> DownloadLessonFileAsync(int id)
        {
            var lessonFile = await _context.Lessons.FindAsync(id);
            if (lessonFile == null)
            {
                throw new Exception("File not found");
            }

            var filePath = Path.Combine("Uploads\\Lesson", lessonFile.FileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = lessonFile.FileName
            };
        }

        public async Task<List<LessonDTO>> GetAllLessonsAsync()
        {
            var lessons = await _context.Lessons
                .Include(l => l.Resources)
                .ToListAsync();
            return _mapper.Map<List<LessonDTO>>(lessons);
        }

        public async Task<Lesson> UpdateLessonAsync(CreateLessonDTO lessonDTO, int id, IFormFile file)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return null;
            }
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("Uploads\\Lesson", lesson.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var fileName = file.FileName;
                filePath = Path.Combine("Uploads\\Lesson", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                lesson.SentDate = DateTime.Now;
                lesson.FileName = fileName;
                lesson.Status = 0;
            }
            _mapper.Map(lessonDTO, lesson);
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }
    }
}
