using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourcesService _resourceService;
        public ResourcesController(IResourcesService resourceService)
        {
            _resourceService = resourceService;
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-resources")]
        public async Task<IActionResult> CreateResources([FromForm] CreateResourcesDTO resourcesDTO, IFormFile file)
        {
            try
            {
                var resources = await _resourceService.CreateResourcesAsync(resourcesDTO, file);
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("update-resources/{id}")]
        public async Task<IActionResult> UpdateResources([FromForm] CreateResourcesDTO lessonDTO, int id, IFormFile file)
        {
            try
            {
                var resources = await _resourceService.UpdateResourcesAsync(lessonDTO, id, file);
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpDelete("delete-resources/{id}")]
        public async Task<ActionResult> DeleteResources(int id)
        {
            var result = await _resourceService.DeleteResourcesAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("approve-resources/{id}")]
        public async Task<IActionResult> ApproveResources(ApproveDTO approveDTO, int id)
        {
            try
            {
                var resources = await _resourceService.ApproveResourcesAsync(approveDTO, id);
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("download-resourcesFile/{id}")]
        public async Task<IActionResult> DownloadResourcesFile(int id)
        {
            try
            {
                var fileStreamResult = await _resourceService.DownloadResourcesFileAsync(id);
                return fileStreamResult;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
