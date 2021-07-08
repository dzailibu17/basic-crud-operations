﻿using Model.DTOs;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public Grade? Grade { get; set; }

        public CourseDTO Course { get; set; }
        public UserDTO User { get; set; }
    }
}