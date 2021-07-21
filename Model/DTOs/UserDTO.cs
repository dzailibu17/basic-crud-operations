using System;
using System.Collections.Generic;

namespace Model.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}
