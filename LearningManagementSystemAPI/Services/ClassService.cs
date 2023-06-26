using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class ClassService : IClassService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public ClassService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Class> CreateClassAsync(CreateClassDTO classDTO)
        {
            var classroom = _mapper.Map<Class>(classDTO);
            await _context.Classes.AddAsync(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var classroom = await _context.Classes.FirstOrDefaultAsync(c => c.ClassId == id);

            if (classroom != null)
            {
                _context.Classes.Remove(classroom);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ClassDTO>> GetAllClassAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            return _mapper.Map<List<ClassDTO>>(classes);
        }

        public async Task<Class> UpdateClassAsync(CreateClassDTO classDTO, int id)
        {
            var classroom = await _context.Classes.FindAsync(id);
            if (classroom == null)
            {
                return null;
            }
            _mapper.Map(classDTO, classroom);
            _context.Classes.Update(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }
    }
}
