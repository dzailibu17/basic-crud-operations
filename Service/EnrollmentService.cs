using Interface.Repositories;
using Interface.Services;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
        }

        public EnrollmentDTO AddEnrollment(EnrollmentDTO enrollment)
        {
            return _enrollmentRepository.AddEnrollment(enrollment);
        }

        public EnrollmentDTO DeleteEnrollment(int ID)
        {
            return _enrollmentRepository.DeleteEnrollment(ID);
        }

        public EnrollmentDTO GetEnrollmentByID(int ID)
        {
            return _enrollmentRepository.GetEnrollmentByID(ID);
        }

        public List<EnrollmentDTO> GetEnrollments()
        {
            return _enrollmentRepository.GetEnrollments().ToList();
        }

        public EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChanges)
        {
            return _enrollmentRepository.UpdateEnrollment(enrollmentChanges);
        }
    }
}
