using System.Collections.Generic;
using System.Linq;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _contexto;

        public DepartamentoService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        public List<Departamento> BuscarTodos()
        {
            return _contexto.Departamento.OrderBy(x => x.Nome).ToList();
        }

    }
}
