using Interface.Repositories;
using Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository.Users;
using Repository.Courses;
using Repository.Enrollments;
using Service;

namespace BasicCrudOperations.Helpers
{
    public static class ServiceCollectionHelper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();

            return services;
        }

        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            return services;
        }
    }
}
