using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class CourseDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Title { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}