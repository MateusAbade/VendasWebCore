using Microsoft.EntityFrameworkCore;
using VendasWebCore.Data;
using VendasWebCore.Models;

namespace VendasWebCore.Services
{
    public class ServiceVendas
    {
        private readonly VendasWebCoreContext _context;
        public ServiceVendas(VendasWebCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Vendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result =  from obj in _context.Vendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >=minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result.Include(x => x.vendedores).Include(x => x.vendedores.Dep).OrderByDescending(x => x.Data).ToListAsync();
        }

    }
}
