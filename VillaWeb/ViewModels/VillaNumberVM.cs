using Microsoft.AspNetCore.Mvc.Rendering;
using Villa.Domain.Entities;
namespace Villa.Web.ViewModels
{
    public class VillaNumberVM
    {
        public VilaNumber? VillaNumber { get; set; }
        public IEnumerable<SelectListItem>? VillaList { get; set; }
    }
}
