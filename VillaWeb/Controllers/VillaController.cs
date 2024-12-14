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
    }
}
