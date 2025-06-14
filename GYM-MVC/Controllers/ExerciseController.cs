using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    //[Authorize(Roles ="Admin")]
    public class ExerciseController : Controller {
        private readonly IExcerciseRepo _repo;

        public ExerciseController(IExcerciseRepo repo) {
            _repo = repo;
        }

        public IActionResult GetAll() {
            var exercises = _repo.GetAll();
            return View(exercises);
        }

        public IActionResult Details(int id) {
            var exercise = _repo.GetById(id);
            if (exercise == null) return NotFound();
            return View(exercise);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Exercise ex) {
            if (!ModelState.IsValid) return View(ex);
            await _repo.Add(ex);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            var exercise = await _repo.GetById(id);
            if (exercise == null) return NotFound();
            return View(exercise);
        }

        [HttpPost]
        public IActionResult Edit(Exercise ex) {
            if (!ModelState.IsValid) return View(ex);
            _repo.Update(ex);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            var exercise = _repo.GetById(id);
            if (exercise == null) return NotFound();
            _repo.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public IActionResult DeleteRange(List<Exercise> exercises) {
            if (exercises == null || !exercises.Any()) return NotFound();
            _repo.DeleteRange(exercises);
            return RedirectToAction(nameof(GetAll));
        }
    }
}