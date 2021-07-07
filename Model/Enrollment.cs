using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public User Student { get; set; }
    }

    public enum Grade
    {
        A, B, C, D, F
    }
}
