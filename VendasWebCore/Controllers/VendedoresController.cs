using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using VendasWebCore.Models;
using VendasWebCore.Models.ViewModels;
using VendasWebCore.Services;
using VendasWebCore.Services.Exception;

namespace VendasWebCore.Controllers
{
    public class VendedoresController : Controller
    {
        private ServiceVendedor _serviceVendedor;
        private ServiceDepartamento _serviceDepartamento;

        public VendedoresController(ServiceVendedor serviceVendedor, ServiceDepartamento serviceDepartamento)
        {
            _serviceVendedor = serviceVendedor;
            _serviceDepartamento = serviceDepartamento;
        }

        public IActionResult Index()
        {
            var list = _serviceVendedor.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _serviceDepartamento.FindAll();
            var viewModel = new FormVendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _serviceVendedor.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não forncecido"});
            }

            var obj = _serviceVendedor.FindById(id.Value);
            if(obj == null) { 
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!"});
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _serviceVendedor.Remove(id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = _serviceVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = _serviceVendedor.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }

            List<Departamento> departamentos = _serviceDepartamento.FindAll();

            FormVendedorViewModel viewModel = new FormVendedorViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if( id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não coresponde" });
            }
            try
            {
                _serviceVendedor.Update(vendedor);
                return RedirectToAction(nameof(Index));

            }catch(NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { e.Message});
            }catch(DBConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { e.Message });
            }


        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);

        }

    }
}
