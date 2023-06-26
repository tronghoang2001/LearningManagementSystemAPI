using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list-department")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                return Ok(await _departmentService.GetAllDepartmentAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-department")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDTO departmentDTO)
        {
            var department = await _departmentService.CreateDepartmentAsync(departmentDTO);

            return Ok(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-department/{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(CreateDepartmentDTO departmentDTO, int id)
        {
            try
            {
                var department = await _departmentService.UpdateDepartmentAsync(departmentDTO, id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-department/{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }
    }
}
