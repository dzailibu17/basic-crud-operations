using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Repositories
{
    public interface IEnrollmentRepository
    {
        EnrollmentDTO GetEnrollmentByID(int ID);
        IEnumerable<EnrollmentDTO> GetEnrollments();
        EnrollmentDTO Add(EnrollmentDTO enrollment);
        EnrollmentDTO Update(EnrollmentDTO enrollmentChanges);
        EnrollmentDTO Delete(int ID);
    }
}
