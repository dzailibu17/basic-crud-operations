using Interface.Services;
using Microsoft.Extensions.DependencyInjection;
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


            return services;
        }
    }
}
