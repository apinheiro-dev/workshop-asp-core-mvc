using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendasService _registroVendasService;

        public RegistroVendasController(RegistroVendasService registroVendasService)
        {
            _registroVendasService = registroVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year,1,1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;
            }
            ViewData["dataInicial"] = dataInicial.Value.ToString("dd-MM-yyyy");
            ViewData["dataFinal"] = dataFinal.Value.ToString("dd-MM-yyyy");
            var resultado = await _registroVendasService.BuscarPorDataAsync(dataInicial, dataFinal);
            return View(resultado);
        }

        public async Task<IActionResult> BuscaAgrupada (DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;
            }
            ViewData["dataInicial"] = dataInicial.Value.ToString("dd-MM-yyyy");
            ViewData["dataFinal"] = dataFinal.Value.ToString("dd-MM-yyyy");
            var resultado = await _registroVendasService.BuscarPorDataAgrupadaAsync(dataInicial, dataFinal);
            return View(resultado);
        }
    }
}