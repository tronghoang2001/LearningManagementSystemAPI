using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("list-class")]
        public async Task<IActionResult> GetAllClass()
        {
            try
            {
                return Ok(await _classService.GetAllClassAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-class")]
        public async Task<IActionResult> CreateClass(CreateClassDTO classDTO)
        {
            var classroom = await _classService.CreateClassAsync(classDTO);

            return Ok(classroom);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("update-class/{id}")]
        public async Task<ActionResult<Class>> UpdateClass(CreateClassDTO classDTO, int id)
        {
            try
            {
                var classroom = await _classService.UpdateClassAsync(classDTO, id);
                return Ok(classroom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpDelete("delete-class/{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            var result = await _classService.DeleteClassAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }
    }
}
