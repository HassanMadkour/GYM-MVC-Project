using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers
{
    public class WorkoutPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
