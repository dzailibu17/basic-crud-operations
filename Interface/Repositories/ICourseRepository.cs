using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Repositories
{
    public interface ICourseRepository
    {
        CourseDTO GetCourseByID(int ID);
        IEnumerable<CourseDTO> GetCourses();
        CourseDTO Add(CourseDTO course);
        CourseDTO Update(CourseDTO courseChanges);
        CourseDTO Delete(int ID);
    }
}
