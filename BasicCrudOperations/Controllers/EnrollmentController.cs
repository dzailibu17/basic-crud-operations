using Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace BasicCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet("Enrollments")]
        public IActionResult Get()
        {
            var enrollments = _enrollmentService.GetEnrollments();
            if (enrollments == null)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }

        [HttpGet("Enrollments/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
           var enrollment = _enrollmentService.GetEnrollmentByID(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost("Enrollments")]
        public IActionResult Post([FromBody] EnrollmentDTO enrollmentDTO)
        {
            var enrollment = _enrollmentService.AddEnrollment(enrollmentDTO);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
        
        [HttpPut("Enrollments/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] EnrollmentDTO enrollmentDTO)
        {
            enrollmentDTO.ID = id;
            var enrollment =  _enrollmentService.UpdateEnrollment(enrollmentDTO);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpDelete("Enrollments/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var enrollment = _enrollmentService.DeleteEnrollment(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
    }
}
