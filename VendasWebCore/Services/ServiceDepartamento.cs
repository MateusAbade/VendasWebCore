using Microsoft.EntityFrameworkCore;
using VendasWebCore.Data;
using VendasWebCore.Models;

namespace VendasWebCore.Services
{
    public class ServiceDepartamento
    {
        private readonly VendasWebCoreContext _context;

        public ServiceDepartamento(VendasWebCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
