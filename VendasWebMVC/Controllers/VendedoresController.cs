using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var lista = _vendedorService.BuscarTodos();
            return View(lista);
        }

        public IActionResult Criar()
        {
            var departamentos = _departamentoService.BuscarTodos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedorService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apagar(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.BuscarTodos();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }
            try
            {

                _vendedorService.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}