using Interface.Repositories;
using Model.DTOs;
using Model.Exceptions;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DbModels.DbModels context;

        public CourseRepository(DbModels.DbModels context)
        {
            this.context = context;
        }

        public CourseDTO AddCourse(CourseDTO course)
        {
            context.Courses.Add(new Course
            {
                ID = FindNewID(),
                Credits = course.Credits,
                Title = course.Title,
            });
            context.SaveChanges();
            return course;
        }

        public CourseDTO DeleteCourse(int ID)
        {
            Course course = context.Courses.Find(ID);
            if (course != null)
            {
                var deletedCourse = new CourseDTO
                {
                    ID = course.ID,
                    Credits = course.Credits,
                    Title = course.Title,
                };
                context.Courses.Remove(course);
                context.SaveChanges();
                return deletedCourse;
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
                    ID = existingCourse.ID,
                    Credits = existingCourse.Credits,
                    Title = existingCourse.Title,
                };
            }
            throw new NotFoundException(String.Format("Course with ID = {0} does not exist.", ID));
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            return context.Courses.Select(c => new CourseDTO
            {
                ID = c.ID,
                Credits = c.Credits,
                Title = c.Title,
            });
        }

        public CourseDTO UpdateCourse(CourseDTO courseChangesDTO)
        {
            if (context.Courses.Any(x => x.ID == courseChangesDTO.ID))
            {
                var courseChanges = new Course
                {
                    ID = courseChangesDTO.ID,
                    Credits = courseChangesDTO.Credits,
                    Title = courseChangesDTO.Title,
                };
                var course = context.Courses.Attach(courseChanges);
                course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return courseChangesDTO;
            }
            return null;
        }

        private int FindNewID(int? id = null)
        {
            if (!id.HasValue)
            {
                id = context.Courses.Any() ? context.Courses.Count() + 1 : 1;
            }
            if (context.Courses.Find(id) != null)
            {
                id += 1;
                FindNewID(id);
            }
            return id.Value;
        }
    }
}
