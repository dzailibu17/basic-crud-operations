using Interface.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using System.Threading.Tasks;

namespace BasicCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IIdentityUserService _accountService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(IIdentityUserService accountService, SignInManager<IdentityUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpPost("Registration")]
        public IActionResult Register(IdentityUserDTO user)
        {
            _accountService.RegisterUesr(user);
            return Ok(user.User);
        }

        [HttpPost("Login")]
        public IActionResult Login(IdentityUserDTO user)
        {
            return Ok(_accountService.LoginUser(user));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("home", "User");
        }
    }
}