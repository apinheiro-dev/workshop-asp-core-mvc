using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Models
{
    public class VendasWebMVCContext : DbContext
    {
        public VendasWebMVCContext (DbContextOptions<VendasWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<VendasWebMVC.Models.Departamento> Departamento { get; set; }
    }
}
