using Microsoft.AspNetCore.Mvc;
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
    }
}
