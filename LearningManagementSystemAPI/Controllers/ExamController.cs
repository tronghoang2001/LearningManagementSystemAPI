using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("get-all-exam")]
        public async Task<ActionResult<List<ExamsDTO>>> GetAllExam(int? subjectId, int? lecturers, int? status)
        {
            var exams = await _examService.GetAllExamAsync(subjectId, lecturers, status);
            return Ok(exams);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("exam-by-id/{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            return exam == null ? NotFound() : Ok(exam);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("approve-exam/{id}")]
        public async Task<IActionResult> ApproveExam(ApproveDTO approveDTO, int id)
        {
            try
            {
                var exam = await _examService.ApproveExamAsync(approveDTO, id);
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
