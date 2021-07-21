using System.Collections.Generic;

namespace Model.DTOs
{
    public class CourseDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}