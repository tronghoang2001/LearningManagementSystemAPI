using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IPrivateFilesService
    {
        public Task<List<PrivateFilesDTO>> GetAllPrivateFilesAsync();
        public Task<PrivateFiles> CreatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, IFormFile file);
        public Task<PrivateFiles> UpdatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, int id, IFormFile file);
        public Task<bool> DeletePrivateFilesAsync(int id);
    }
}
