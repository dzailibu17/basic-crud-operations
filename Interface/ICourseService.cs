using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface ICourseService
    {
        Course GetCourseByID(int ID);
        IEnumerable<Course> GetCourses();
        Course Add(Course course);
        Course Update(Course courseChanges);
        Course Delete(int ID);
    }
}
