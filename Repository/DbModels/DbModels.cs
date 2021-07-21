using Microsoft.EntityFrameworkCore;

namespace Repository.DbModels
{
    public class DbModels : DbContext
    {
        public DbModels(DbContextOptions<DbModels> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
