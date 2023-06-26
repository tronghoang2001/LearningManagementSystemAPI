using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IClassService
    {
        public Task<List<ClassDTO>> GetAllClassAsync();
        public Task<Class> CreateClassAsync(CreateClassDTO classDTO);
        public Task<Class> UpdateClassAsync(CreateClassDTO classDTO, int id);
        public Task<bool> DeleteClassAsync(int id);
    }
}
