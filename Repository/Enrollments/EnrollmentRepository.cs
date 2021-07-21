using Interface.Repositories;
using Model.DTOs;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
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
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public EnrollmentDTO DeleteEnrollment(int ID)
        {
            try
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
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public EnrollmentDTO GetEnrollmentByID(int ID)
        {
            try
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
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public IEnumerable<EnrollmentDTO> GetEnrollments()
        {
            try
            {
                return context.Enrollments.Select(e => new EnrollmentDTO
                {
                    ID = e.ID,
                    CourseID = e.CourseID,
                    UserID = e.UserID,
                    Grade = e.Grade,
                });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public EnrollmentDTO UpdateEnrollment(EnrollmentDTO enrollmentChangesDTO)
        {
            try
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
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
