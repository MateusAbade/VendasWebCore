using Microsoft.AspNetCore.Mvc;

namespace VendasWebCore.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
