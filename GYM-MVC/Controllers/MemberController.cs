using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberRepo memberRepo;
        public MemberController(IMemberRepo memberRepo)
        {
            this.memberRepo = memberRepo;
        }

        //public IActionResult Index()
        //{
        //    return RedirectToAction(nameof(GetAll));
        //}

        public IActionResult Index()
        {
            var members = memberRepo.GetAll();
            return View(members);
        }

        public async Task<IActionResult> Details(int id)
        {
            var member = await memberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (!ModelState.IsValid) return View(member);
            await memberRepo.Add(member);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await memberRepo.GetById(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if (!ModelState.IsValid) return View(member);
            memberRepo.Update(member);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            memberRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteRange(List<int> memberIds)
        {
            var members = memberRepo.GetAll().Where(m => memberIds.Contains(m.Id)).ToList();
            memberRepo.DeleteRange(members);
            return RedirectToAction(nameof(Index));
        }
    }
}
