using Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AuthController: Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
            if (user == null)
            {
                throw new Exception("Not found user");
            }

            var result = 
                await _signInManager.PasswordSignInAsync(
                    loginUserDto.Email, loginUserDto.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(loginUserDto.ReturnUrl);
            }

            throw new Exception();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var user = new AppUser
            {
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                LastName = registerUserDto.LastName,
                PhoneNumber = registerUserDto.PhoneNumber

            };

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(registerUserDto.ReturnUrl);
            }

            throw new Exception("User wasn't register");
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
