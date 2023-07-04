using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public AnswerService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Answer> CreateAnswerAsync(CreateAnswerDTO answerDTO)
        {
            var answer = _mapper.Map<Answer>(answerDTO);
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();

            var questionDetails = new QuestionDetails
            {
                AnswerId = answer.AnswerId,
                QuestionId = answerDTO.QuestionId,
                AccountId = answerDTO.AccountId,
            };
            _context.QuestionDetails.Add(questionDetails);
            await _context.SaveChangesAsync();

            return answer;
        }
    }
}
