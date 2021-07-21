using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Repositories
{
    public interface ICourseRepository
    {
        CourseDTO GetCourseByID(int ID);
        IEnumerable<CourseDTO> GetCourses();
        CourseDTO AddCourse(CourseDTO course);
        CourseDTO UpdateCourse(CourseDTO courseChanges);
        CourseDTO DeleteCourse(int ID);
    }
}
