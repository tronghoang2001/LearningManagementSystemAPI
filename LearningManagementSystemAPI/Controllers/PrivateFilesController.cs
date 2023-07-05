using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateFilesController : ControllerBase
    {
        private readonly IPrivateFilesService _privateFilesService;
        public PrivateFilesController(IPrivateFilesService privateFilesService)
        {
            _privateFilesService = privateFilesService;
        }

        [Authorize]
        [HttpGet("list-privateFiles")]
        public async Task<IActionResult> GetPrivateFilesByAccountId(int accountId)
        {
            try
            {
                return Ok(await _privateFilesService.GetPrivateFilesByAccountIdAsync(accountId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("create-privateFiles")]
        public async Task<IActionResult> CreatePrivateFiles([FromForm] CreatePrivateFilesDTO privateFilesDTO, IFormFile file)
        {
            try
            {
                var privateFile = await _privateFilesService.CreatePrivateFilesAsync(privateFilesDTO, file);
                return Ok(privateFile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update-privateFiles/{id}")]
        public async Task<IActionResult> UpdatePrivateFiles([FromForm] CreatePrivateFilesDTO privateFilesDTO, int id, IFormFile file)
        {
            try
            {
                var privateFile = await _privateFilesService.UpdatePrivateFilesAsync(privateFilesDTO, id, file);
                return Ok(privateFile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("rename-privateFiles/{id}")]
        public async Task<IActionResult> RenamePrivateFiles(RenamePrivateFilesDTO privateFilesDTO, int id)
        {
            try
            {
                var privateFile = await _privateFilesService.RenamePrivateFilesAsync(privateFilesDTO, id);
                return Ok(privateFile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete-privateFiles/{id}")]
        public async Task<ActionResult> DeletePrivateFiles(int id)
        {
            var result = await _privateFilesService.DeletePrivateFilesAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }


        [Authorize]
        [HttpGet("download-privateFiles/{id}")]
        public async Task<IActionResult> DownloadPrivateFilesFile(int id)
        {
            try
            {
                var fileStreamResult = await _privateFilesService.DownloadPrivateFilesAsync(id);
                return fileStreamResult;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
