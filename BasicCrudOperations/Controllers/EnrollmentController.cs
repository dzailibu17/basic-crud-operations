using Interface;
using Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpGet("GetEnrollments")]
        public IActionResult Get()
        {
            return Ok(_enrollmentService.GetEnrollments());
        }

        [HttpGet("GetEnrollmentByID")]
        public IActionResult Get([FromQuery] int id)
        {
            return Ok(_enrollmentService.GetEnrollmentByID(id));
        }

        [HttpPost("AddEnrollment")]
        public IActionResult Post([FromBody] EnrollmentDTO enrollmentDTO)
        {
            return Ok(_enrollmentService.Add(enrollmentDTO));
        }
        
        [HttpPut("UpdateEnrollment")]
        public IActionResult Put([FromBody] EnrollmentDTO enrollmentDTO)
        {
            return Ok(_enrollmentService.Update(enrollmentDTO));
        }

        [HttpDelete("DeleteEnrollment")]
        public IActionResult Delete(int id)
        {
            return Ok(_enrollmentService.Delete(id));
        }
    }
}
