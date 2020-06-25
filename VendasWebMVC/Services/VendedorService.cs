using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
        private readonly VendasWebMVCContext _contexto;

        public VendedorService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        public List<Vendedor> FindAll()
        {
            return _contexto.Vendedor.ToList();
        }
    }
}
