using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.App.Mvc.EntityLayer.Concrete;
using Todo.App.Mvc.PresentationLayer.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };
            var result = await _userManager.CreateAsync(appUser, registerViewModel.ConfirmPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Identity");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "App");
                }
                else
                {
                    ViewBag.Danger = "Password or Username doesn't match";
                    return View();
                }
            }
            return View();
        }

        
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
