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
        public List<EnrollmentDTO> GetEnrollments()
        {
            return new List<EnrollmentDTO>(_enrollmentRepository.GetEnrollments());
        }
    }
}
