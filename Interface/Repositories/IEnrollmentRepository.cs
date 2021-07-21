using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Repositories
{
    public interface IEnrollmentRepository
    {
        EnrollmentDTO GetEnrollmentByID(int ID);
        IEnumerable<EnrollmentDTO> GetEnrollments();
        EnrollmentDTO AddEnrollment(EnrollmentDTO enrollment);
        EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChanges);
        EnrollmentDTO DeleteEnrollment(int ID);
    }
}
