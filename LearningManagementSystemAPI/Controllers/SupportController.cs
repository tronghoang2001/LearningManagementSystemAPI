using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;
        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [Authorize]
        [HttpPost("create-support")]
        public async Task<IActionResult> CreateSupport(CreateSupportDTO supportDTO)
        {
            var support = await _supportService.CreateSupportAsync(supportDTO);

            return Ok(support);
        }
    }
}
