using Interface;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Repository.UserRepository;
using Repository.CourseRepository;
using Repository.EnrollmentRepository;

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
            //services.AddScoped<UserService, UserRepository>();
            //services.AddScoped<CourseService, CourseRepository>();
            //services.AddScoped<EnrollmentService, EnrollmentRepository>();

            return services;
        }
    }
}
