using Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace BasicCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourses")]
        public IActionResult Get()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpGet("GetCourseByID")]
        public IActionResult Get([FromQuery] int id)
        {
            return Ok(_courseService.GetCourseByID(id));
        }

        [HttpPost("AddCourse")]
        public IActionResult Post([FromBody] CourseDTO course)
        {
            return Ok(_courseService.AddCourse(course));
        }

        [HttpPut("UpdateCourse")]
        public IActionResult Put([FromBody] CourseDTO courseDTO)
        {
            return Ok(_courseService.UpdateCourse(courseDTO));
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok(_courseService.DeleteCourse(id));
        }
    }
}
