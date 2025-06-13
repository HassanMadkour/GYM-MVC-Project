using GYM_MVC.ViewModels.MembershipViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class MemberShipController : Controller {

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateMembershipViewModel model) {
            if (!ModelState.IsValid) return View(model);
            return RedirectToAction("Index", "Home");
        }
    }
}