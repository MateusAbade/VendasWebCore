using Microsoft.AspNetCore.Mvc;
using VendasWebCore.Models;
using VendasWebCore.Services;

namespace VendasWebCore.Controllers
{
    public class VendedoresController : Controller
    {
        private ServiceVendedor _serviceVendedor;

        public VendedoresController(ServiceVendedor serviceVendedor)
        {
            _serviceVendedor = serviceVendedor;
        }

        public IActionResult Index()
        {
            var list = _serviceVendedor.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _serviceVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
