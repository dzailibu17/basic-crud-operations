using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Interface.Repositories;
using Interface.Services;
using Model;
using Model.DTOs;
using Repository.DbModels;

namespace Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
        }

        public EnrollmentDTO Add(EnrollmentDTO enrollment)
        {
            return _enrollmentRepository.Add(enrollment);
        }

        public EnrollmentDTO Delete(int ID)
        {
            return _enrollmentRepository.Delete(ID);
        }

        public EnrollmentDTO GetEnrollmentByID(int ID)
        {
            return _enrollmentRepository.GetEnrollmentByID(ID);
        }

        public List<EnrollmentDTO> GetEnrollments()
        {
            return new List<EnrollmentDTO>(_enrollmentRepository.GetEnrollments());
        }

        public EnrollmentDTO Update(EnrollmentDTO enrollmentChanges)
        {
            return _enrollmentRepository.Update(enrollmentChanges);
        }
    }
}
