using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.Include(x => x.Villa).ToList();
            return View(villaNumbers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(u => new SelectListItem {
            Text=u.Name,
            Value=u.Id.ToString()
            });
            //ViewData["VillaList"] = list;
            ViewBag.VillaList = list;
            return View();
        }
        [HttpPost]
        public IActionResult Create(VilaNumber obj)
        {
            ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                _db.VillaNumbers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The Villa Number has been created successfully.";
                return RedirectToAction(nameof(Index), "VillaNumber");
            }
            return View(obj);
        }
    }
}
