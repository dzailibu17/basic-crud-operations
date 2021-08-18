using Interface.Repositories;
using Model.DTOs;
using Model.Exceptions;
using System;
using System.Threading.Tasks;
using i = Microsoft.AspNetCore.Identity;

namespace Repository.IdentityUser
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly i.UserManager<i.IdentityUser> _userManager;
        private readonly i.SignInManager<i.IdentityUser> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly DbModels.DbModels _context;

        public IdentityUserRepository(i.UserManager<i.IdentityUser> userManager,
                                      i.SignInManager<i.IdentityUser> signInManager,
                                      IUserRepository userRepository,
                                      DbModels.DbModels context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _context = context;
        }

        public IdentityUserDTO RegisterUesr(IdentityUserDTO user)
        {
            return RegisterUesrAsync(user).Result;
        }

        private async Task<IdentityUserDTO> RegisterUesrAsync(IdentityUserDTO user)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var User = new i.IdentityUser { UserName = user.User.Email, Email = user.User.Email };
                var result = await _userManager.CreateAsync(User, user.Password);

                if (!result.Succeeded)
                {
                    throw new BadRequestException();
                }

                _userRepository.AddUser(user.User);
                await transaction.CommitAsync();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return user;
        }

        public async Task<string> LoginUserAsync(IdentityUserDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.User.Email, user.Password, false, false);
            if (result.Succeeded)
            {
                //_signInManager.getUserIdentityTokenAsync()
                return "token";
            }
            throw new NotFoundException("Invalid login attempt.");
        }

        public string LoginUser(IdentityUserDTO user)
        {
            return LoginUserAsync(user).Result;
        }
    }
}
