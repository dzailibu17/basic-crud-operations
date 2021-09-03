using AutoMapper;
using Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Exceptions;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DbModels.DbModels _context;
        private readonly IMapper _mapper;

        public EnrollmentRepository(DbModels.DbModels context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EnrollmentDTO AddEnrollment(EnrollmentDTO enrollmentDTO)
        {
            _context.Enrollments.Add(_mapper.Map<Enrollment>(enrollmentDTO));
            _context.SaveChanges();

            return enrollmentDTO;
        }

        public EnrollmentDTO DeleteEnrollment(int ID)
        {
            Enrollment enrollment = _context.Enrollments.Find(ID);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
                return _mapper.Map<EnrollmentDTO>(enrollment);
            }

            throw new NotFoundException(String.Format("Enrollment with ID = {0} does not exist.", ID));
        }

        public EnrollmentDTO GetEnrollmentByID(int ID)
        {
            var existingEnrollment = _context.Enrollments.Find(ID);
            if (existingEnrollment != null)
            {
                return _mapper.Map<EnrollmentDTO>(existingEnrollment);
            }

            throw new NotFoundException(String.Format("Enrollment with ID = {0} does not exist.", ID));
        }

        public IEnumerable<EnrollmentDTO> GetEnrollments()
        {
            IEnumerable<Enrollment> Enrollments = _context.Enrollments.Include(e => e.User).
                                                                       Include(e => e.Course);
            return _mapper.Map<IEnumerable<EnrollmentDTO>>(Enrollments); 
        }

        public EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChangesDTO)
        {
            if (_context.Enrollments.Any(x => x.ID == enrollmentChangesDTO.ID))
            {
                var enrollment = _context.Enrollments.Attach(_mapper.Map<Enrollment>(enrollmentChangesDTO));
                enrollment.State = EntityState.Modified;
                _context.SaveChanges();

                return enrollmentChangesDTO;
            }

            throw new NotFoundException(String.Format("Enrollment with ID = {0} does not exist.", enrollmentChangesDTO.ID));
        }
    }
}
