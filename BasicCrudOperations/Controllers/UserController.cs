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

        [HttpGet("Users")]
        public IActionResult Get()
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("Users/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var user = _userService.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Users")]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            var user =  _userService.AddUser(userDTO);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("Users/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            userDTO.ID = id;
            var user = _userService.UpdateUser(userDTO);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("Users/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var user = _userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
