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

        public List<CourseDTO> GetCourses()
        {
            return new List<CourseDTO>(_courseRepository.GetCourses());
        }
    }
}
