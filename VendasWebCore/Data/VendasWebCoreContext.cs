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

        public DbSet<VendasWebCore.Models.Departamento> Departamento { get; set; } = default!;
    }
}
