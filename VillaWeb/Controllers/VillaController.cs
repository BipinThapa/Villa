using Microsoft.AspNetCore.Mvc;
using Villa.Infrastructure.Data;

namespace Villa.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext db) {
            _db= db;
        }
        public IActionResult Index()
        {
            var villa = _db.Villas.ToList();
            return View(villa);
        }
    }
}
