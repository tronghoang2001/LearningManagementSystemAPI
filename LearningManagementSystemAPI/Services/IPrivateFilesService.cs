using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Services
{
    public interface IPrivateFilesService
    {
        public Task<List<PrivateFilesDTO>> GetPrivateFilesByAccountIdAsync(int accountId);
        public Task<PrivateFiles> CreatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, IFormFile file);
        public Task<PrivateFiles> UpdatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, int id, IFormFile file);
        public Task<PrivateFiles> RenamePrivateFilesAsync(RenamePrivateFilesDTO privateFilesDTO, int id);
        public Task<bool> DeletePrivateFilesAsync(int id);
        public Task<FileStreamResult> DownloadPrivateFilesAsync(int id);
    }
}
