using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Model;
using Repository.DbModels;

namespace Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly DbModels context;

        public EnrollmentService(DbModels context)
        {
            this.context = context;
        }

        public Enrollment Add(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
            return enrollment;
        }

        public Enrollment Delete(int ID)
        {
            Enrollment enrollment = context.Enrollments.Find(ID);
            if (enrollment != null)
            {
                context.Enrollments.Remove(enrollment);
                context.SaveChanges();
            }
            return enrollment;

        }

        public Enrollment GetEnrollmentByID(int ID)
        {
            return context.Enrollments.Find(ID);
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return context.Enrollments;
        }

        public Enrollment Update(Enrollment enrollmentChanges)
        {
            var enrollment = context.Enrollments.Attach(enrollmentChanges);
            enrollment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return enrollmentChanges;
        }
    }
}
