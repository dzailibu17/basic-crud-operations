using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Services
{
    public interface IEnrollmentService
    {
        EnrollmentDTO GetEnrollmentByID(int ID);
        List<EnrollmentDTO> GetEnrollments();
        EnrollmentDTO Add(EnrollmentDTO enrollment);
        EnrollmentDTO Update(EnrollmentDTO enrollmentChanges);
        EnrollmentDTO Delete(int ID);
    }
}
