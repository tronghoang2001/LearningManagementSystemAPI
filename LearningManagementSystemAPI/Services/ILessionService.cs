using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface ILessionService
    {
        public Task<Lesson> CreateLessonAsync(CreateLessonDTO lessonDTO, IFormFile file);
        public Task<Lesson> UpdateLessonAsync(CreateLessonDTO lessonDTO, int id, IFormFile file);
        public Task<bool> DeleteLessonAsync(int id);
    }
}
