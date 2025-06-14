using GYM_MVC.Core.Entities;
using GYM_MVC.Core.Helper;
using GYM_MVC.ViewModels.MembershipViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class MemberShipController : Controller {

        [HttpGet]
        public IActionResult Create() {
            CreateMembershipViewModel model = new CreateMembershipViewModel();
            model.MembershipTypeList = EnumHelper.ToSelectList<MembershipType>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateMembershipViewModel model) {
            model.MembershipTypeList = EnumHelper.ToSelectList<MembershipType>();
            if (!ModelState.IsValid) return View(model);

            return RedirectToAction("Index", "Home");
        }
    }
}