using Model.Enums;

namespace Model.DTOs
{
    public class EnrollmentDTO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public Grade? Grade { get; set; }

        public CourseDTO Course { get; set; }
        public UserDTO User { get; set; }
    }
}
