using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public class SupportService : ISupportService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public SupportService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Support> CreateSupportAsync(CreateSupportDTO supportDTO)
        {
            var support = _mapper.Map<Support>(supportDTO);
            await _context.Supports.AddAsync(support);
            await _context.SaveChangesAsync();
            return support;
        }
    }
}
