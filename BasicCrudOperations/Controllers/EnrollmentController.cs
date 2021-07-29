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
            return Ok(_enrollmentService.GetEnrollments());
        }

        [HttpGet("Enrollments/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_enrollmentService.GetEnrollmentByID(id));
        }

        [HttpPost("Enrollments")]
        public IActionResult Post([FromBody] EnrollmentDTO enrollmentDTO)
        {
            return Ok(_enrollmentService.AddEnrollment(enrollmentDTO));
        }
        
        [HttpPut("Enrollments/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] EnrollmentDTO enrollmentDTO)
        {
            enrollmentDTO.ID = id;
            return Ok(_enrollmentService.UpdateEnrollment(enrollmentDTO));
        }

        [HttpDelete("Enrollments/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_enrollmentService.DeleteEnrollment(id));
        }
    }
}
