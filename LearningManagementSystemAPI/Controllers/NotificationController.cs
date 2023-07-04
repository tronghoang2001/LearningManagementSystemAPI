using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpGet("list-notification")]
        public async Task<IActionResult> GetNotificationBySubjectId(int subjectId)
        {
            try
            {
                return Ok(await _notificationService.GetNotificationBySubjectIdAsync(subjectId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-notification")]
        public async Task<IActionResult> CreateNotification(CreateNotificationDTO notificationDTO)
        {
            var notification = await _notificationService.CreateNotificationAsync(notificationDTO);

            return Ok(notification);
        }

    }
}
