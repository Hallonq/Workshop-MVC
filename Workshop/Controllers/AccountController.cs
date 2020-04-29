using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workshop.IdentityData;
using Workshop.ViewModels;

namespace Workshop.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager { get; set; }
        private SignInManager<ApplicationUser> SignInManager { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = new ApplicationUser { UserName = user.Username };

                var result = await UserManager.CreateAsync(userIdentity, user.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userIdentity, isPersistent: false);
                    TempData["Operation"] = "Account Registration Successful.";
                    return RedirectToAction("Index", "Home", TempData);
                }
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                // RememberMe works but login-cookie creates even if rememberme is false.
                var result = await SignInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    TempData["Operation"] = $"Welcome, { user.Username }.";
                    return RedirectToAction("Index", "Home", TempData);
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
