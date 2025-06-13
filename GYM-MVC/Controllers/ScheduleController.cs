using GYM_MVC.Core.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class ScheduleController : Controller {
        private readonly IUnitOfWork unitOfWork;

        public ScheduleController(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index() {
            unitOfWork.ScheduleRepo.GetAll();
            return View();
        }
    }
}