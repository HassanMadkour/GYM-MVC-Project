using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class AccountController : Controller {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IMapper mapper;
        private IEmailSender emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IEmailSender emailSender
            ) {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.emailSender = emailSender;
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
        public async Task<IActionResult> RegisterTheMember(RegisterMemberViewModel registerMemberViewModel) {
            if (ModelState.IsValid) {
                ApplicationUser user = mapper.Map<RegisterMemberViewModel, ApplicationUser>(registerMemberViewModel);
                Member member = mapper.Map<RegisterMemberViewModel, Member>(registerMemberViewModel);
                IdentityResult result = _userManager.CreateAsync(user, registerMemberViewModel.Password).Result;
                if (result.Succeeded) {
                    Task<string> code = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code.Result }, Request.Scheme);
                    await emailSender.SendEmailAsync(user.Email, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">Confirm</a>");

                    return View("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid User");

            return View("Register", registerMemberViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code) {
            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;
            if (user == null) {
                return NotFound();
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded) {
                signInManager.SignInAsync(user, false);
                return View("Index", "Home");
            }
            return View("Error");
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return View("Login");
        }

        [HttpGet]
        public IActionResult ForgetPassword() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordViewModel forgotPasswordViewModel) {
            if (ModelState.IsValid) {
                ApplicationUser user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
                if (user != null) {
                    string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    string callbackUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, code = code }, Request.Scheme);
                    await emailSender.SendEmailAsync(forgotPasswordViewModel.Email, "Reset your password", "Please reset your password by clicking this link: <a href=\"" + callbackUrl + "\">Reset</a>");
                }
            }
            return View("Index", "Home");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email) {
            if (token == null || email == null)
                return RedirectToAction("Index", "Home");

            return View(new ResetPasswordViewModel { Code = token, Email = email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model) {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {
                return NotFound();
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded) {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}