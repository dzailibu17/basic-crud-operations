using Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicCrudOperations.Controllers
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

        [HttpGet("home")]
        public IActionResult Home()
        {
            return Ok("Welcome");
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("GetUserByID")]
        public IActionResult Get([FromQuery] int id)
        {
            return Ok(_userService.GetUserByID(id));
        }

        [HttpPost("AddUser")]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            return Ok(_userService.AddUser(userDTO));
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UserDTO userDTO)
        {
            return Ok(_userService.UpdateUser(userDTO));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok(_userService.DeleteUser(id));
        }
    }
}
