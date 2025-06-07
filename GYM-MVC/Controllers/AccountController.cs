using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GYM_MVC.Controllers {

    public class AccountController : Controller {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IMapper mapper;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper) {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login() {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginTheUser(LoginUserViewModel loginUserViewModel) {
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

        [HttpGet]
        public IActionResult Register() {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterTheMember(RegisterMemberViewModel registerMemberViewModel) {
            if (ModelState.IsValid) {
                ApplicationUser user = mapper.Map<RegisterMemberViewModel, ApplicationUser>(registerMemberViewModel);
                Member member = mapper.Map<RegisterMemberViewModel, Member>(registerMemberViewModel);
                IdentityResult result = _userManager.CreateAsync(user, registerMemberViewModel.Password).Result;
                if (result.Succeeded) {
                    signInManager.SignInAsync(user, false);
                }
                return View("Register", registerMemberViewModel);
            }
            return RedirectToAction("Register", registerMemberViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return View("Login");
        }

        public IActionResult ForgetPassword() {
            return View();
        }

        public IActionResult ResetPassword() {
            return View();
        }
    }
}