using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPost("create-topic")]
        public async Task<IActionResult> CreateTopic(CreateTopicDTO topicDTO)
        {
            var topic = await _topicService.CreateTopicAsync(topicDTO);

            return Ok(topic);
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpPut("update-topic/{id}")]
        public async Task<ActionResult<Topic>> UpdateTopic(UpdateTopicDTO topicDTO, int id)
        {
            try
            {
                var topic = await _topicService.UpdateTopicAsync(topicDTO, id);
                return Ok(topic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin,Lecturers")]
        [HttpDelete("delete-topic/{id}")]
        public async Task<ActionResult> DeleteTopic(int id)
        {
            var result = await _topicService.DeleteTopicAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }
    }
}
