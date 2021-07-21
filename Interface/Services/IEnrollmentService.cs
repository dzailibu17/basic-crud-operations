using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IEnrollmentService
    {
        EnrollmentDTO GetEnrollmentByID(int ID);
        List<EnrollmentDTO> GetEnrollments();
        EnrollmentDTO AddEnrollment(EnrollmentDTO enrollment);
        EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChanges);
        EnrollmentDTO DeleteEnrollment(int ID);
    }
}
