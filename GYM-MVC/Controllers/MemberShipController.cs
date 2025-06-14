using AutoMapper;
using GYM_MVC.Core.Entities;
using GYM_MVC.Core.Helper;
using GYM_MVC.Core.IUnitOfWorks;
using GYM_MVC.ViewModels.MembershipViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers {

    public class MemberShipController : Controller {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MemberShipController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create() {
            CreateMembershipViewModel model = new CreateMembershipViewModel();
            model.MembershipTypeList = EnumHelper.ToSelectList<MembershipType>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMembershipViewModel model) {
            model.MembershipTypeList = EnumHelper.ToSelectList<MembershipType>();
            if (!ModelState.IsValid) return View(model);
            await unitOfWork.MembershipRepo.Add(mapper.Map<Membership>(model));
            await unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}