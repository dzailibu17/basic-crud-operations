using Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.DbModels;
using Model.DTOs;

namespace Repository.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DbModels.DbModels context;

        public EnrollmentRepository(DbModels.DbModels context)
        {
            this.context = context;
        }

        public EnrollmentDTO Add(EnrollmentDTO enrollment)
        {
            context.Enrollments.Add(new DbModels.Enrollment
            {
                ID = enrollment.ID,
                CourseID = enrollment.CourseID,
                UserID = enrollment.UserID,
                Grade = enrollment.Grade,
                
            });
            context.SaveChanges();
            return enrollment;
        }

        public EnrollmentDTO Delete(int ID)
        {
            Enrollment enrollment = context.Enrollments.Find(ID);
            if (enrollment != null)
            {
                var deletedEnrollment = new EnrollmentDTO
                {
                    ID = enrollment.ID,
                    CourseID = enrollment.CourseID,
                    UserID = enrollment.UserID,
                    Grade = enrollment.Grade,
                };
                context.Enrollments.Remove(enrollment);
                context.SaveChanges();
                return deletedEnrollment;
            }
            return null;
        }

        public EnrollmentDTO GetEnrollmentByID(int ID)
        {
            var existingEnrollment = context.Enrollments.Find(ID);
            if (existingEnrollment != null)
            {
                return new EnrollmentDTO
                { 
                    ID = existingEnrollment.ID,
                    CourseID = existingEnrollment.CourseID,
                    UserID = existingEnrollment.UserID,
                    Grade = existingEnrollment.Grade,
                };
            }
            return null;
        }

        public IEnumerable<EnrollmentDTO> GetEnrollments()
        {
            var enrollments = context.Enrollments;
            List<EnrollmentDTO> enrollmentsDTO = new List<EnrollmentDTO>();
            foreach (Enrollment enrollment in enrollments)
            {
                enrollmentsDTO.Add(new EnrollmentDTO
                {
                    ID = enrollment.ID,
                    CourseID = enrollment.CourseID,
                    UserID = enrollment.UserID,
                    Grade = enrollment.Grade,
                });
            }
            return enrollmentsDTO;
        }

        public EnrollmentDTO Update(EnrollmentDTO enrollmentChangesDTO)
        {

            var enrollmentChanges = new Enrollment 
            {
                ID = enrollmentChangesDTO.ID,
                CourseID = enrollmentChangesDTO.CourseID,
                UserID = enrollmentChangesDTO.UserID,
                Grade = enrollmentChangesDTO.Grade,
            };
            var enrollment = context.Enrollments.Attach(enrollmentChanges);
            enrollment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return enrollmentChangesDTO;
        }
    }
}
