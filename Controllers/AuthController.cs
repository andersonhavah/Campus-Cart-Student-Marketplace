using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Campus_Cart_Student_Marketplace.Models;

namespace Campus_Cart_Student_Marketplace.Controllers
{
    [Authorize] // Ensure only logged-in users can access
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Sign the user out
                await _signInManager.SignOutAsync();

                // Redirect to home page after logout
                return RedirectToAction("/");
            }
            catch
            {
                // Handle unexpected errors
                return StatusCode(500, "An error occurred while signing out.");
            }
        }
    }
}
