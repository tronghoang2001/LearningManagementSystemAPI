using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list-role")]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                return Ok(await _roleService.GetAllRoleAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(CreateRoleDTO roleDTO)
        {
            var quyen = await _roleService.CreateRoleAsync(roleDTO);

            return Ok(quyen);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-role/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }
    }
}
