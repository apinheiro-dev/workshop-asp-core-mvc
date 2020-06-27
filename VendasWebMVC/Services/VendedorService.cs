using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using Microsoft.EntityFrameworkCore; // Instrução Include, para Join das Tabelas
using VendasWebMVC.Services.Exceptions;

namespace VendasWebMVC.Services
{
    public class VendedorService
    {
        private readonly VendasWebMVCContext _contexto;

        public VendedorService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Vendedor>> BuscarTodosAsync()
        {
            return await _contexto.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarPorIdAsync(int id)
        {
            // Join
            return await _contexto.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
            //Eager Loading - Carregar outros objetos com o objeto principal
        }

        public async Task RemoverAsync(int id)
        {
            try
            {
                var obj = await _contexto.Vendedor.FindAsync(id);
                _contexto.Vendedor.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não é possível apagar vendedor(a) porque possui vendas.");
            }
        }

        public async Task AtualizarAsync(Vendedor obj)
        {
            bool temAlgum = await _contexto.Vendedor.AnyAsync(x => x.Id == obj.Id);

            if (!temAlgum)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _contexto.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
