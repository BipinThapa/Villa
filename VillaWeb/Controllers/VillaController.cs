using Microsoft.AspNetCore.Mvc;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext db) {
            _db= db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var villa = _db.Villas.ToList();
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
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index), "Villa");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Vila? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
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
                _db.Villas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index), "Villa");
            }
            return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Vila? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Vila obj)
        {
            Vila? objFromDb = _db.Villas.FirstOrDefault(u=>u.Id==obj.Id);
            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index), "Villa");
            }
            return View(obj);
        }
    }
}
