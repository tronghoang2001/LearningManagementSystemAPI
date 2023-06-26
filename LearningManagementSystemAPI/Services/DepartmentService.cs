using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Department> CreateDepartmentAsync(CreateDepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentId == id);

            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public async Task<Department> UpdateDepartmentAsync(CreateDepartmentDTO departmentDTO, int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }
            _mapper.Map(departmentDTO, department);
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
