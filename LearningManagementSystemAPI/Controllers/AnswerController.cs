using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("create-answer")]
        public async Task<IActionResult> CreateAnswer(CreateAnswerDTO answerDTO)
        {
            var answer = await _answerService.CreateAnswerAsync(answerDTO);

            return Ok(answer);
        }
    }
}
