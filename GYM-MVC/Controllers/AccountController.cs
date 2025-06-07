using GYM.Domain.Entities;
using GYM_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class AccountController : Controller {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            this._userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel) {
            if (ModelState.IsValid) {
                ApplicationUser user = await _userManager.FindByNameAsync(loginUserViewModel.UserName);
                if (user != null) {
                    bool result = await _userManager.CheckPasswordAsync(user, loginUserViewModel.Password);
                    if (result) {
                        await signInManager.SignInAsync(user, loginUserViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("validation", "Invalid User");
            return View("Login", loginUserViewModel);
        }

        public IActionResult Register() {
            return View();
        }

        public IActionResult Logout() {
            return View();
        }

        public IActionResult ForgetPassword() {
            return View();
        }

        public IActionResult ResetPassword() {
            return View();
        }
    }
}