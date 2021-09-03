using Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class EnrollmentDTO
    {
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public Grade? Grade { get; set; }

        public CourseDTO Course { get; set; }
        public UserDTO User { get; set; }
    }
}
