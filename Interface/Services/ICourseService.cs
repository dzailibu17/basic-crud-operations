using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Services
{
    public interface ICourseService
    {
        List<CourseDTO> GetCourses();
    }
}
