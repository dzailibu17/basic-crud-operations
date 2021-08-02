using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}
