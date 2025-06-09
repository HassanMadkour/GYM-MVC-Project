using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class TrainerController : Controller
    {
        private readonly ITrainerRepo trainerRepo;
        public TrainerController(ITrainerRepo trainerRepo)
        {
            this.trainerRepo = trainerRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var trainers = trainerRepo.GetAll();
            return View(trainers);
        }
        public IActionResult Details(int id)
        {
            var trainer = trainerRepo.GetById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (!ModelState.IsValid) return View(trainer);
            await trainerRepo.Add(trainer);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var trainer = await trainerRepo.GetById(id);
            if (trainer == null) return NotFound();
            return View(trainer);
        }
        [HttpPost]
        public IActionResult Edit(Trainer trainer)
        {
            if (!ModelState.IsValid) return View(trainer);
            trainerRepo.Update(trainer);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var trainer = trainerRepo.GetById(id);
            if (trainer == null) return NotFound();
            trainerRepo.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpPost]
        public IActionResult DeleteRange(List<Trainer> trainers)
        {
            if (trainers == null || !trainers.Any()) return NotFound();
            trainerRepo.DeleteRange(trainers);
            return RedirectToAction(nameof(GetAll));

        }
    }
}
