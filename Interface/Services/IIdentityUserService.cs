using Model.DTOs;

namespace Interface.Services
{
    public interface IIdentityUserService
    {
        IdentityUserDTO RegisterUesr(IdentityUserDTO user);
        string LoginUser(IdentityUserDTO user);
    }
}