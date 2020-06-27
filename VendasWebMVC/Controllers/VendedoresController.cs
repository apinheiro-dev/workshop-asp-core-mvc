using System;
using System.Collections.Generic;
using System.Diagnostics;      
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceptions;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var lista = await _vendedorService.BuscarTodosAsync();
            return View(lista);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _departamentoService.BuscarTodosAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Criar(Vendedor vendedor)
        {
            // Validação no lado do Servidor caso esteja desabilitado no Cliente (JavaScript)
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.BuscarTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(vendedor);
            }
            await _vendedorService.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Apagar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = await _vendedorService.BuscarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                await _vendedorService.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = e.Message });
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = await _vendedorService.BuscarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Editar (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "O Id não foi fornecido!" });
            }

            var obj = await _vendedorService.BuscarPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não localizado!" });
            }

            List<Departamento> departamentos = await _departamentoService.BuscarTodosAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            // Validação no lado do Servidor caso esteja desabilitado no Cliente (JavaScript)
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.BuscarTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(vendedor);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { mensagem = "Id não correspondente!" });
            }
            try
            {

                await _vendedorService.AtualizarAsync(vendedor);
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