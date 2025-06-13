using GYM.Domain.Entities;
using GYM_MVC.Core.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    //[Authorize(Roles = "Admin")]
    public class MemberController : Controller {
        private readonly IUnitOfWork unitOfWork;

        public MemberController(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        //public IActionResult Index()
        //{
        //    return RedirectToAction(nameof(GetAll));
        //}

        [HttpGet]
        public IActionResult Index() {
            var members = unitOfWork.MemberRepo.GetAll();
            return View(members);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            var member = await unitOfWork.MemberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member) {
            if (!ModelState.IsValid) return View(member);
            await unitOfWork.MemberRepo.Add(member);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            var member = await unitOfWork.MemberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPut]
        public IActionResult Edit(Member member) {
            if (!ModelState.IsValid) return View(member);
            unitOfWork.MemberRepo.Update(member);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            unitOfWork.MemberRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult DeleteRange(List<int> memberIds) {
            var members = unitOfWork.MemberRepo.GetAll().Where(m => memberIds.Contains(m.Id)).ToList();
            unitOfWork.MemberRepo.DeleteRange(members);
            return RedirectToAction(nameof(Index));
        }
    }
}