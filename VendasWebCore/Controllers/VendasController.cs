using Microsoft.AspNetCore.Mvc;
using VendasWebCore.Services;

namespace VendasWebCore.Controllers
{
    public class VendasController : Controller
    {
        private readonly ServiceVendas _serviceVendas;

        public VendasController(ServiceVendas serviceVendas)
        {
            _serviceVendas = serviceVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples( DateTime? minDate, DateTime?maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _serviceVendas.FindByDateAsync(minDate,maxDate);

            return View(result);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _serviceVendas.FindByDateGrupoAsync(minDate, maxDate);

            return View(result);
        }
    }
}
