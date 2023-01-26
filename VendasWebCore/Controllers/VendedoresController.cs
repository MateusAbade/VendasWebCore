﻿using Microsoft.AspNetCore.Mvc;
using VendasWebCore.Models;
using VendasWebCore.Models.ViewModels;
using VendasWebCore.Services;

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
                return NotFound();
            }

            var obj = _serviceVendedor.FindById(id.Value);
            if(obj == null) { 
                return NotFound();
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
    }
}
