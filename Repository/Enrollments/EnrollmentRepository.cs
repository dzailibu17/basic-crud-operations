using Interface.Repositories;
using Model.DTOs;
using Repository.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DbModels.DbModels context;

        public EnrollmentRepository(DbModels.DbModels context)
        {
            this.context = context;
        }

        public EnrollmentDTO AddEnrollment(EnrollmentDTO enrollment)
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

        public EnrollmentDTO DeleteEnrollment(int ID)
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
            return context.Enrollments.Select(e => new EnrollmentDTO
            {
                ID = e.ID,
                CourseID = e.CourseID,
                UserID = e.UserID,
                Grade = e.Grade,
            });
        }

        public EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChangesDTO)
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
