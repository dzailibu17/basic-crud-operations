using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface ICourseService
    {
        CourseDTO GetCourseByID(int ID);
        List<CourseDTO> GetCourses(); 
        CourseDTO AddCourse(CourseDTO course);
        CourseDTO UpdateCourse(CourseDTO courseChanges);
        CourseDTO DeleteCourse(int ID);
    }
}
