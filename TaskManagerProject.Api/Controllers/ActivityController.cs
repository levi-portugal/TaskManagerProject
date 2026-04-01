using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerProject.DTOs;
using TaskManagerProject.DTOs.ActivityDTO;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _activityService.GetAll();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var activity = _activityService.GetById(id);
            if (activity == null) return NotFound();

            return Ok(activity);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActivityRequestDto dto)
        {
            _activityService.CreateActivity(dto);
            return StatusCode(201, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update (string id, [FromBody] ActivityRequestDto dto)
        {
            _activityService.EditTask(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _activityService.DeleteTask(id);
            return NoContent();
        }
    }
}
