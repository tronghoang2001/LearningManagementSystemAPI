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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list-permission")]
        public async Task<IActionResult> GetAllPermission()
        {
            try
            {
                return Ok(await _permissionService.GetAllPermissionAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-permission")]
        public async Task<IActionResult> CreatePermission(CreatePermissionDTO permissionDTO)
        {
            var permission = await _permissionService.CreatePermissionAsync(permissionDTO);

            return Ok(permission);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-permission/{id}")]
        public async Task<ActionResult<Permission>> UpdatePermission(CreatePermissionDTO permissionDTO, int id)
        {
            try
            {
                var permission = await _permissionService.UpdatePermissionAsync(permissionDTO, id);
                return Ok(permission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-permission/{id}")]
        public async Task<ActionResult> DeletePermission(int id)
        {
            var result = await _permissionService.DeletePermissionAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }
    }
}
