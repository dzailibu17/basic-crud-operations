using Interface.Repositories;
using Model.DTOs;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                context.Courses.Add(new Course
                {
                    ID = FindNewID(true),
                    Credits = course.Credits,
                    Title = course.Title,
                });
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return course;
        }

        public CourseDTO DeleteCourse(int ID)
        {
            try
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
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public CourseDTO GetCourseByID(int ID)
        {
            try
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
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            try
            {
                return context.Courses.Select(c => new CourseDTO
                {
                    ID = c.ID,
                    Credits = c.Credits,
                    Title = c.Title,
                });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }
        public CourseDTO UpdateCourse(CourseDTO courseChangesDTO)
        {
            try
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
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return courseChangesDTO;
        }
    
        private int FindNewID(bool isFirst, int? id = null)
        {
            if (isFirst)
            {
                id = context.Courses.Any() ? context.Courses.Count() + 1 : 1;
            }
            if (context.Courses.Find(id) == null )
            {
                return (int)id;
            }
            else
            {
                id += 1;
                FindNewID(false, id);
                return (int)id;
            }
        }
    }
}
