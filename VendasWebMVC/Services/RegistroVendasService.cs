using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
    public class RegistroVendasService
    {
        private readonly VendasWebMVCContext _contexto;

        public RegistroVendasService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<RegistroVendas>> BuscarPorDataAsync (DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = from obj in _contexto.RegistroVendas select obj;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataFinal.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento,RegistroVendas>>> BuscarPorDataAgrupadaAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = from obj in _contexto.RegistroVendas select obj;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataFinal.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
