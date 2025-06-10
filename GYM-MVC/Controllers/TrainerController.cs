using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.Core.IUnitOfWorks;
using GYM_MVC.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYM_MVC.Controllers
{
    public class TrainerController : Controller
    {
        IUnitOfWork UnitOfWork;
        IMapper mapper;
        public TrainerController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult GetAllTrainees()
        {
            var trainers = UnitOfWork.TrainerRepo.GetAll().ToList();

            return View(mapper.Map<List<DisplayTrainerVM>>(trainers));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateTrainerVM trainerVM)
        {
            if (ModelState.IsValid)
            {
                if (trainerVM.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "Trainers");
                    string fileName = Guid.NewGuid() + Path.GetExtension(trainerVM.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await trainerVM.ImageFile.CopyToAsync(fileStream);
                    }
                    trainerVM.ImagePath = @$"/uploads/Trainers/{fileName}";
                }
                else
                    trainerVM.ImagePath = @$"/uploads/Trainers/DefaultImage.jpg";
                await UnitOfWork.TrainerRepo.Add(mapper.Map<Trainer>(trainerVM));
                await UnitOfWork.Save();
                return RedirectToAction(nameof(GetAllTrainees));
            }
            return View(trainerVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null || !await UnitOfWork.TrainerRepo.Contains(t => t.Id == id))
                return NotFound("Trainer is Not Exist!!");
            var trainer = await UnitOfWork.TrainerRepo.GetById(id.Value);
            return View(mapper.Map<EditTrainerVM>(trainer));

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id ,EditTrainerVM trainerVM)
        {
            if (id is null || id != trainerVM.Id)
                return NotFound();
            if(ModelState.IsValid)
            {
                if (trainerVM.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "Trainers");
                    string fileName = Guid.NewGuid() + Path.GetExtension(trainerVM.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await trainerVM.ImageFile.CopyToAsync(fileStream);
                    }
                    trainerVM.ImagePath = @$"/uploads/Trainers/{fileName}";
                }
                UnitOfWork.TrainerRepo.Update(mapper.Map<Trainer>(trainerVM));
                await UnitOfWork.Save();
                return RedirectToAction(nameof(GetAllTrainees));
            }
            return View(trainerVM);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || !await UnitOfWork.TrainerRepo.Contains(t => t.Id == id))
                return NotFound("Trainer is Not Exist!!");
            var trainer =await  UnitOfWork.TrainerRepo.GetById(id.Value);
            return View(trainer);

        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id is null || !await UnitOfWork.TrainerRepo.Contains(t => t.Id == id))
                return NotFound("Trainer is Not Exist!!");
            UnitOfWork.TrainerRepo.Delete(id.Value);
            await UnitOfWork.Save();
            return RedirectToAction(nameof(GetAllTrainees));

        }

    } 
}
