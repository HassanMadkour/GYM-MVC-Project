using AutoMapper;
using GYM_MVC.Core.IUnitOfWorks;
using GYM_MVC.Data.UnitOfWorks;
using GYM_MVC.Models;
using GYM_MVC.ViewModels.ScheduleViewModels;
using GYM_MVC.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace GYM_MVC.Controllers {

    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork,IMapper mapper )
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

      
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var schedules = await Task.Run(() => unitOfWork.ScheduleRepo.GetAll().ToList());
            var scheduleViewModels = mapper.Map<List<ScheduleViewModel>>(schedules);
            var trainrs = mapper.Map < List < DisplayTrainerVM >> (await Task.Run(() => unitOfWork.TrainerRepo.GetAll().ToList()));

            var scheduleTable = scheduleViewModels
                .GroupBy(s => s.Time.ToString(@"hh\:mm"))
                .Select(g => new
                {
                    Time = g.Key,
                    Monday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Monday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Tuesday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Tuesday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Wednesday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Wednesday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Thursday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Thursday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Friday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Friday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Saturday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Saturday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName)),
                    Sunday = string.Join(", ", g.Where(s => s.DayOfWeek.Equals("Sunday", StringComparison.OrdinalIgnoreCase)).Select(s => s.ClassName))
                })
                .OrderBy(s => s.Time)
                .ToList();
            ViewBag.Trainers = trainrs;
            ViewBag.ScheduleTable = scheduleTable;
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}