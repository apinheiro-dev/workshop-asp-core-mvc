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

        public List<Vendedor> BuscarTodos()
        {
            return _contexto.Vendedor.ToList();
        }

        public void Inserir(Vendedor obj)
        {
            _contexto.Add(obj);
            _contexto.SaveChanges();
        }

        public Vendedor BuscarPorId(int id)
        {
            // Join
            return _contexto.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
            //Eager Loading - Carregar outros objetos com o objeto principal
        }

        public void Remover(int id)
        {
            var obj = _contexto.Vendedor.Find(id);
            _contexto.Vendedor.Remove(obj);
            _contexto.SaveChanges();
        }

        public void Atualizar(Vendedor obj)
        {
            if (!_contexto.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _contexto.Update(obj);
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
