using Microsoft.AspNetCore.Mvc;
using VendasWebCore.Models;

namespace VendasWebCore.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Nome = "pão" });
            list.Add(new Departamento { Id = 2, Nome = "feijão" });
            return View(list);
        }
    }
}
