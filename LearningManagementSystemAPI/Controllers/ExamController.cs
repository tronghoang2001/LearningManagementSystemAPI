using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-question")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionBankDTO questionBankDTO)
        {
            var exam = await _examService.CreateQuestionAsync(questionBankDTO);

            return Ok(exam);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-essay-question")]
        public async Task<IActionResult> CreateEssayQuestion(CreateEssayQuestionDTO essayQuestionDTO)
        {
            var question = await _examService.CreateEssayQuestionAsync(essayQuestionDTO);

            return Ok(question);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-exam")]
        public async Task<IActionResult> CreateExam(CreateExamDTO examDTO)
        {
            var exam = await _examService.CreateExamAsync(examDTO);

            return Ok(exam);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("upload-exam-file")]
        public async Task<IActionResult> UploadExamFile([FromForm] UploadExamFileDTO examFileDTO, IFormFile file)
        {
            try
            {
                var exam = await _examService.UploadExamFileAsync(examFileDTO, file);
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("list-question")]
        public async Task<IActionResult> GetAllQuestion()
        {
            try
            {
                return Ok(await _examService.GetAllQuestionAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("question-by-id/{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _examService.GetQuestionByIdAsync(id);
            return question == null ? NotFound() : Ok(question);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("update-question/{id}")]
        public async Task<ActionResult<Class>> UpdateQuestion(CreateQuestionBankDTO questionBankDTO, int id)
        {
            try
            {
                var question = await _examService.UpdateQuestionAsync(questionBankDTO, id);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpDelete("delete-question/{id}")]
        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var result = await _examService.DeleteQuestionAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }

        [Authorize]
        [HttpGet("download-examFile/{id}")]
        public async Task<IActionResult> DownloadExamFile(int id)
        {
            try
            {
                var fileStreamResult = await _examService.DownloadExamFileAsync(id);
                return fileStreamResult;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
