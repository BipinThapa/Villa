using Microsoft.AspNetCore.Mvc;
using Villa.Application.Common.Interfaces;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;
        public VillaController(IVillaRepository villaRepo) {
            _villaRepo= villaRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var villa = _villaRepo.GetAll();
            return View(villa);
        }
        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vila obj)
        {
            if (obj.Name.Count()<1)
            {
                ModelState.AddModelError("Name","name cannot have single character");
            }
            if (obj.Name==obj.Description)
            {
                ModelState.AddModelError("","The Description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _villaRepo.Add(obj);
                _villaRepo.Save();
                TempData["success"] = "The Villa has been created successfully.";
                return RedirectToAction(nameof(Index), "Villa");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Vila? obj = _villaRepo.Get(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Vila obj)
        {
            if (ModelState.IsValid && obj.Id>0)
            {
                _villaRepo.Update(obj);
                _villaRepo.Save();
                TempData["success"] = "The Villa has been updated successfully.";
                return RedirectToAction(nameof(Index), "Villa");
            }
            return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Vila? obj = _villaRepo.Get(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Vila obj)
        {
            Vila? objFromDb = _villaRepo.Get(u=>u.Id==obj.Id);
            if (objFromDb is not null)
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();
                TempData["success"]= "The Villa has been delete successfully.";
                return RedirectToAction(nameof(Index), "Villa");
            }
            TempData["error"] = "The Villa could not be deleted.";
            return View(obj);
        }
    }
}
