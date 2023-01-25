using VendasWebCore.Data;
using VendasWebCore.Models;

namespace VendasWebCore.Services
{
    public class ServiceVendedor
    {
        private readonly VendasWebCoreContext _context;

        public ServiceVendedor(VendasWebCoreContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
    }

}
