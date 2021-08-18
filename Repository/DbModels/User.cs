using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Repository.DbModels
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
