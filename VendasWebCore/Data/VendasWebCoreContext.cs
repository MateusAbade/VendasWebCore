using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebCore.Models;

namespace VendasWebCore.Data
{
    public class VendasWebCoreContext : DbContext
    {
        public VendasWebCoreContext (DbContextOptions<VendasWebCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
        public DbSet<Vendas> Vendas { get; set; } = default!;
    }
}
