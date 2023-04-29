using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Dashboard.ViewModels;
using Web.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email); // Ehmed@123 maqa@compar.edu.az vusal@compar.edu.az

            SignInResult result = await _signInManager.PasswordSignInAsync(user,loginViewModel.Password,true, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
         
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            User newUser = new()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                PhotoUrl = "/img/avatar.png"
            };

            IdentityResult result = await _userManager.CreateAsync(newUser,registerViewModel.Password);

            if(result.Succeeded)
                return RedirectToAction("Login");

            return View(registerViewModel);
        }

    }
}