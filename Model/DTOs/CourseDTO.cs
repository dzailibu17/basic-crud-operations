using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class CourseDTO
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Title { get; set; }
        
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}