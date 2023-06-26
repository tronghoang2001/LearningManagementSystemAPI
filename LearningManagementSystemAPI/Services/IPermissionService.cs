using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IPermissionService
    {
        public Task<List<PermissionDTO>> GetAllPermissionAsync();
        public Task<Permission> CreatePermissionAsync(CreatePermissionDTO permissionDTO);
        public Task<Permission> UpdatePermissionAsync(CreatePermissionDTO permissionDTO, int id);
        public Task<bool> DeletePermissionAsync(int id);
    }
}
