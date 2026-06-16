using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Campus_Cart_Student_Marketplace.Models;
using Campus_Cart_Student_Marketplace.DTOs;

namespace Campus_Cart_Student_Marketplace.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Address = model.Address,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                model.Password,
                false,
                false);

            if (!result.Succeeded)
                return BadRequest();

            return Ok();
        }
    }
}