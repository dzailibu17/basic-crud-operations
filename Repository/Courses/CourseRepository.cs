using Interface.Repositories;
using Model.DTOs;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DbModels.DbModels context;

        public CourseRepository(DbModels.DbModels context)
        {
            this.context = context;
        }

        public CourseDTO Add(CourseDTO course) 
        {
            context.Courses.Add(new DbModels.Course
            {
                 CourseID = course.CourseID,
                 Credits = course.Credits,
                 Title = course.Title,
            });
            context.SaveChanges();
            return course;
        }

        public CourseDTO Delete(int ID)
        {
            Course course = context.Courses.Find(ID);
            if (course != null)
            {
                var deletetCourse = new CourseDTO 
                {
                    CourseID = course.CourseID,
                    Credits = course.Credits,
                    Title = course.Title,
                };
                context.Courses.Remove(course);
                context.SaveChanges();
                return deletetCourse;
            }
            return null;
        }

        public CourseDTO GetCourseByID(int ID)
        {
            var existingCourse = context.Courses.Find(ID);
            if (existingCourse != null)
            {
                return new CourseDTO
                {
                    CourseID = existingCourse.CourseID,
                    Credits = existingCourse.Credits,
                    Title = existingCourse.Title,
                };
            }
            return null;
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses = context.Courses;
            List<CourseDTO> coursesDTO = new List<CourseDTO>();
            foreach (Course course in courses)
            {
                coursesDTO.Add(new CourseDTO
                {
                    CourseID = course.CourseID,
                    Credits = course.Credits,
                    Title = course.Title,
                });
            }
            return coursesDTO;
        }

        public CourseDTO Update(CourseDTO courseChangesDTO)
        {
            var courseChanges = new Course
            {
                CourseID = courseChangesDTO.CourseID,
                Credits = courseChangesDTO.Credits,
                Title = courseChangesDTO.Title,
            };
            var course = context.Courses.Attach(courseChanges);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courseChangesDTO;
        }

    }
}
