using Interface.Repositories;
using Interface.Services;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public CourseDTO AddCourse(CourseDTO course)
        {
            return _courseRepository.AddCourse(course);
        }

        public CourseDTO DeleteCourse(int ID)
        {
            return _courseRepository.DeleteCourse(ID);
        }

        public CourseDTO GetCourseByID(int ID)
        {
            return _courseRepository.GetCourseByID(ID);
        }

        public List<CourseDTO> GetCourses()
        {
            return _courseRepository.GetCourses().ToList();
        }

        public CourseDTO UpdateCourse(CourseDTO courseChanges)
        {
            return _courseRepository.UpdateCourse(courseChanges);
        }
    }
}
