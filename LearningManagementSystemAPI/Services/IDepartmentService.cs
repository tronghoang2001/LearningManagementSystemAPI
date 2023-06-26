using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentDTO>> GetAllDepartmentAsync();
        public Task<Department> CreateDepartmentAsync(CreateDepartmentDTO departmentDTO);
        public Task<Department> UpdateDepartmentAsync(CreateDepartmentDTO departmentDTO, int id);
        public Task<bool> DeleteDepartmentAsync(int id);
    }
}
