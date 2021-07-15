using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Services
{
    public interface ICourseService
    {
        CourseDTO GetCourseByID(int ID);
        List<CourseDTO> GetCourses(); 
        CourseDTO Add(CourseDTO course);
        CourseDTO Update(CourseDTO courseChanges);
        CourseDTO Delete(int ID);

    }
}
