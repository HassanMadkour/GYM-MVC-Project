using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GYM_MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
