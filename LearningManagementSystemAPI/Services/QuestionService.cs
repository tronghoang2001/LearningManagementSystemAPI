using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public QuestionService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Question> CreateQuestionAsync(CreateQuestionDTO questionDTO)
        {
            var question = _mapper.Map<Question>(questionDTO);
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<List<QuestionDTO>> GetAllQuestionAsync(int subjectId)
        {
            var questions = await _context.Questions
                .Include(c => c.Account)
                .Include(c => c.Answers)
                    .ThenInclude(c => c.Account)
                .Where(c => c.SubjectId ==  subjectId)
                .ToListAsync();

            return _mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
