using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public RoleService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> CreateRoleAsync(CreateRoleDTO roleDTO)
        {
            var role = new Role
            {
                Name = roleDTO.Name,
                Description = roleDTO.Name,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                PermissionRoles = new List<PermissionRole>()
            };

            foreach (var permissionId in roleDTO.Permissions)
            {
                var permission = await _context.Permissions.FindAsync(permissionId);
                if (permission != null)
                {
                    var permissionRole = new PermissionRole
                    {
                        Role = role,
                        Permission = permission
                    };
                    role.PermissionRoles.Add(permissionRole);
                }
            }

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _context.Roles
                .Include(c => c.PermissionRoles)
                .FirstOrDefaultAsync(c => c.RoleId == id);

            if (role != null)
            {
                _context.PermissionRoles.RemoveRange(role.PermissionRoles);
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<RoleDTO>> GetAllRoleAsync()
        {
            var roles = await _context.Roles
                .Include(c => c.PermissionRoles)
                    .ThenInclude(c => c.Permission)
                .ToListAsync();

            return _mapper.Map<List<RoleDTO>>(roles);
        }
    }
}
