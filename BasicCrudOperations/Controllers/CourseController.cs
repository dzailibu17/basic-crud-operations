using Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using System;

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

        [HttpGet("Courses")]
        public IActionResult Get()
        {
            var courses = _courseService.GetCourses();
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("Courses/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var course = _courseService.GetCourseByID(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("Courses")]
        public IActionResult Post([FromBody] CourseDTO courseDTO)
        {
            var course = _courseService.AddCourse(courseDTO);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut("Courses/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CourseDTO courseDTO)
        {
            courseDTO.ID = id;
            var course = _courseService.UpdateCourse(courseDTO);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpDelete("Courses/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var course = _courseService.DeleteCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
    }
}
