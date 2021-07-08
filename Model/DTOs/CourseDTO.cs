using System;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Model.DTOs
{
    public class CourseDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<EnrollmentDTO> Enrollments { get; set; }
    }
}