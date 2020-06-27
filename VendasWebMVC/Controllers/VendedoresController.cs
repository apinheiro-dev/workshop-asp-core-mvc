using System;
using System.Collections.Generic;
using System.Diagnostics;      
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
            // Validação no lado do Servidor caso esteja desabilitado no Cliente (JavaScript)
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.BuscarTodos();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(vendedor);
            }
            _vendedorService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Apagar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
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
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
            }

            return View(obj);
        }

        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = _vendedorService.BuscarPorId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
            }

            List<Departamento> departamentos = _departamentoService.BuscarTodos();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            // Validação no lado do Servidor caso esteja desabilitado no Cliente (JavaScript)
            if (!ModelState.IsValid)
            {
                var departamentos = _departamentoService.BuscarTodos();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(vendedor);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não correspondente!" });
            }
            try
            {

                _vendedorService.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message });
            }
           
        }

        public IActionResult Erro (string mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = mensagem,
                //Pegar o Id interno da requisição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}