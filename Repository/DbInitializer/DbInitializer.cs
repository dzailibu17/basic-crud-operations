using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.DbModels;
using System.Linq;

namespace Repository.DbInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(DbModels.DbModels context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new User{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new User{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new User{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new User{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
            new Course{CourseID=1045,Title="Calculus",Credits=4},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4},
            new Course{CourseID=2021,Title="Composition",Credits=3},
            new Course{CourseID=2042,Title="Literature",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{UserID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{UserID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{UserID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{UserID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{UserID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{UserID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{UserID=3,CourseID=1050},
            new Enrollment{UserID=4,CourseID=1050},
            new Enrollment{UserID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{UserID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{UserID=6,CourseID=1045},
            new Enrollment{UserID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}

