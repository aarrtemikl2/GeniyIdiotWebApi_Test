using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeniyIdiotWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user")]
        public async Task<ActionResult<UserDTO>> CreateUserAsync(UserRequestDTO userRequestDTO)
        {
            var userDTO = await _userService.CreateAsync(userRequestDTO);

            return StatusCode(201, userDTO);
        }
    }
}
