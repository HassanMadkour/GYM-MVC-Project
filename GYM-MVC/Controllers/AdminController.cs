using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class AdminController : Controller {

        public IActionResult Dashboard() {
            return View();
        }
    }
}