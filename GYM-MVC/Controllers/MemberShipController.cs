using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers
{
    public class MemberShipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
