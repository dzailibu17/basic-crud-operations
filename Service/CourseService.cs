using Interface;
using Model;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CourseService : ICourseService
    {
        private readonly DbModels context;

        public CourseService(DbModels context)
        {
            this.context = context;
        }

        public Course Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public Course Delete(int ID)
        {
            Course course = context.Courses.Find(ID);
            if(course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return course;
        }

        public Course GetCourseByID(int ID)
        {
            return context.Courses.Find(ID);
        }

        public IEnumerable<Course> GetCourses()
        {
            return context.Courses;
        }

        public Course Update(Course courseChanges)
        {
            var course = context.Courses.Attach(courseChanges);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courseChanges;
        }
    }
}
