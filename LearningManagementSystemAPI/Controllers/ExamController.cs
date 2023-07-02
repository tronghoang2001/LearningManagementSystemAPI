using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("get-all-exam")]
        public async Task<ActionResult<List<ExamDTO>>> GetAllExam(int? subjectId, string? lecturers, int? status)
        {
            var exams = await _examService.GetAllExamAsync(subjectId, lecturers, status);
            return Ok(exams);
        }
    }
}
