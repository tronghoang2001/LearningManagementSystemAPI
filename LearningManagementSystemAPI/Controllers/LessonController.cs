using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessionService _lessionService;
        public LessonController(ILessionService lessionService)
        {
            _lessionService = lessionService;
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-lesson")]
        public async Task<IActionResult> CreateLesson([FromForm] CreateLessonDTO lessonDTO, IFormFile file)
        {
            try
            {
                var lesson = await _lessionService.CreateLessonAsync(lessonDTO, file);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("update-lesson/{id}")]
        public async Task<IActionResult> UpdateLesson([FromForm] CreateLessonDTO lessonDTO, int id, IFormFile file)
        {
            try
            {
                var lesson = await _lessionService.UpdateLessonAsync(lessonDTO, id, file);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpDelete("delete-lesson/{id}")]
        public async Task<ActionResult> DeleteLesson(int id)
        {
            var result = await _lessionService.DeleteLessonAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("approve-lesson/{id}")]
        public async Task<IActionResult> ApproveLesson(ApproveDTO approveDTO, int id)
        {
            try
            {
                var lesson = await _lessionService.ApproveLessonAsync(approveDTO, id);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
