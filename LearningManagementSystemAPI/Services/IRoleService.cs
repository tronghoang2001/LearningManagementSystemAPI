using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IRoleService
    {
        public Task<List<RoleDTO>> GetAllRoleAsync();
        public Task<Role> CreateRoleAsync(CreateRoleDTO roleDTO);
        public Task<bool> DeleteRoleAsync(int id);
    }
}
