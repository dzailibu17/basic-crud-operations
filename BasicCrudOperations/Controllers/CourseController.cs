using Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace BasicCrudOperations.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("Courses")]
        public IActionResult Get()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpGet("Courses/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_courseService.GetCourseByID(id));
        }

        [HttpPost("Courses")]
        public IActionResult Post([FromBody] CourseDTO courseDTO)
        {
            return Ok(_courseService.AddCourse(courseDTO));
        }

        [HttpPut("Courses/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CourseDTO courseDTO)
        {
            courseDTO.ID = id;
            return Ok(_courseService.UpdateCourse(courseDTO));
        }

        [HttpDelete("Courses/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_courseService.DeleteCourse(id));
        }
    }
}
