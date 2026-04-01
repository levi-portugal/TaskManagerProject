using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerProject.DTOs.UserDto;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.ListUser();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserRequestDto dto) 
        {
            _userService.CreateUser(dto);
            return StatusCode(201, dto);
        }
    }
}
