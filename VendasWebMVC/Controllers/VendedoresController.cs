﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var lista = _vendedorService.FindAll();
            return View(lista);
        }
    }
}