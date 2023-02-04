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

        public async Task<IActionResult> Index()
        {
            var list = await _serviceVendedor.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _serviceDepartamento.FindAllAsync();
            var viewModel = new FormVendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {

            await _serviceVendedor.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não forncecido"});
            }

            var obj = await _serviceVendedor.FindByIdAsync(id.Value);
            if(obj == null) { 
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!"});
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceVendedor.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { e.Message });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = await _serviceVendedor.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }
            return View(obj);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = await _serviceVendedor.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }

            List<Departamento> departamentos = await _serviceDepartamento.FindAllAsync();

            FormVendedorViewModel viewModel = new FormVendedorViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if( id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não coresponde" });
            }
            try
            {
                await _serviceVendedor.UpdateAsync(vendedor);
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
