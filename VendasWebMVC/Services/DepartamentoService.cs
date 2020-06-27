using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _contexto;

        public DepartamentoService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        public async Task <List<Departamento>> BuscarTodosAsync()
        {
            return await _contexto.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
