using AutoMapper;
using Interface.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbModels.DbModels _context;
        private readonly IMapper _mapper;

        public CourseRepository(DbModels.DbModels context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CourseDTO AddCourse(CourseDTO courseDTO)
        {
            _context.Courses.Add(_mapper.Map<Course>(courseDTO));
            if (_context.Courses.Any(x => x.ID == courseDTO.ID))
            {
                return null;
            }
            _context.SaveChanges();
            return courseDTO;
        }

        public CourseDTO DeleteCourse(int ID)
        {
            Course course = _context.Courses.Find(ID);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return _mapper.Map<CourseDTO>(course);
            }

            throw new NotFoundException(String.Format("Course with ID = {0} does not exist.", ID));
        }

        public CourseDTO GetCourseByID(int ID)
        {
            var existingCourse = _context.Courses.Find(ID);
            if (existingCourse != null)
            {
                return _mapper.Map<CourseDTO>(existingCourse);
            }

            throw new NotFoundException(String.Format("Course with ID = {0} does not exist.", ID));
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            return _mapper.Map<IEnumerable<CourseDTO>>(_context.Courses.Include(c => c.Enrollments));
        }

        public CourseDTO UpdateCourse(CourseDTO courseChangesDTO)
        {
            if (_context.Courses.Any(x => x.ID == courseChangesDTO.ID))
            {
                var course = _context.Courses.Attach(_mapper.Map<Course>(courseChangesDTO));
                course.State = EntityState.Modified;
                _context.SaveChanges();

                return courseChangesDTO;
            }

            throw new NotFoundException(String.Format("Course with ID = {0} does not exist.", courseChangesDTO.ID));
        }
    }
}
