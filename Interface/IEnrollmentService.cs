using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IEnrollmentService
    {
        Enrollment GetEnrollmentByID(int ID);
        IEnumerable<Enrollment> GetEnrollments();
        Enrollment Add(Enrollment enrollment);
        Enrollment Update(Enrollment enrollmentChanges);
        Enrollment Delete(int ID);
    }
}
