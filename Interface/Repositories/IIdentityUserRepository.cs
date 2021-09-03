using Model.DTOs;

namespace Interface.Repositories
{
    public interface IIdentityUserRepository
    {
        IdentityUserDTO RegisterUesr(IdentityUserDTO user);
        string LoginUser(IdentityUserDTO user);
    }
}
