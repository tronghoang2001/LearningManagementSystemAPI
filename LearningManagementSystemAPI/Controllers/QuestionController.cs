using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("create-question")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDTO questionDTO)
        {
            var question = await _questionService.CreateQuestionAsync(questionDTO);

            return Ok(question);
        }

        [HttpGet("list-question")]
        public async Task<IActionResult> GetAllQuestion()
        {
            try
            {
                return Ok(await _questionService.GetAllQuestionAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
