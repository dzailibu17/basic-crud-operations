using Microsoft.AspNetCore.Identity;
using Model.DTOs;
using Repository.DbModels;

namespace BasicCrudOperations.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<IdentityUser, IdentityUserDTO>().ReverseMap();
        }
    }
}
