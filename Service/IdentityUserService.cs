using Interface.Repositories;
using Interface.Services;
using Model.DTOs;

namespace Service
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly IIdentityUserRepository _identityUserRepository;

        public IdentityUserService(IIdentityUserRepository identityUserRepository)
        {
            _identityUserRepository = identityUserRepository;
        }

        public string LoginUser(IdentityUserDTO user)
        {
            return _identityUserRepository.LoginUser(user);
        }

        public IdentityUserDTO RegisterUesr(IdentityUserDTO user)
        {
            return _identityUserRepository.RegisterUesr(user);
        }
    }
}
