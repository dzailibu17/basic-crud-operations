using Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicCrudOperations.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            return Ok("Welcome");
        }

        [HttpGet("Users")]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("Users/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_userService.GetUserByID(id));
        }

        [HttpPost("Users")]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            return Ok(_userService.AddUser(userDTO));
        }

        [HttpPut("Users/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            userDTO.ID = id;
            return Ok(_userService.UpdateUser(userDTO));
        }

        [HttpDelete("Users/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_userService.DeleteUser(id));
        }
    }
}
