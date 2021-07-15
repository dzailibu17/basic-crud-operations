using Interface.Repositories;
using Interface.Services;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public CourseDTO Add(CourseDTO course)
        {
            _courseRepository.Add(course);
            return course;
        }

        public CourseDTO Delete(int ID)
        {
            return _courseRepository.Delete(ID);
        }

        public CourseDTO GetCourseByID(int ID)
        {
            return _courseRepository.GetCourseByID(ID);
        }

        public List<CourseDTO> GetCourses()
        {
            return new List<CourseDTO>(_courseRepository.GetCourses());
        }

        public CourseDTO Update(CourseDTO courseChanges)
        {
            return _courseRepository.Update(courseChanges);
        }
    }
}
