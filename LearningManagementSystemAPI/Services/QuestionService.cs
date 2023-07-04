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

            var questionDetails = new QuestionDetails
            {
                QuestionId = question.QuestionId,
                AccountId = questionDTO.AccountId,

            };
            _context.QuestionDetails.Add(questionDetails);
            await _context.SaveChangesAsync();

            return question;
        }

        public async Task<List<QuestionDTO>> GetAllQuestionAsync()
        {
            var questions = await _context.Questions
                .Include(c => c.QuestionDetails)
                    .ThenInclude(c => c.Account)
                .Include(c => c.QuestionDetails)
                    .ThenInclude(c => c.Answer)
                .ToListAsync();

            return _mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
