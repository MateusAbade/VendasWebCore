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

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
