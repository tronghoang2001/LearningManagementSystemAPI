using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public PermissionService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Permission> CreatePermissionAsync(CreatePermissionDTO permissionDTO)
        {
            var permission = _mapper.Map<Permission>(permissionDTO);
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<bool> DeletePermissionAsync(int id)
        {
            var permission = await _context.Permissions.FirstOrDefaultAsync(c => c.PermissionId == id);

            if (permission != null)
            {
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<PermissionDTO>> GetAllPermissionAsync()
        {
            var permissions = await _context.Permissions.ToListAsync();
            return _mapper.Map<List<PermissionDTO>>(permissions);
        }

        public async Task<Permission> UpdatePermissionAsync(CreatePermissionDTO permissionDTO, int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return null;
            }
            _mapper.Map(permissionDTO, permission);
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
    }
}
