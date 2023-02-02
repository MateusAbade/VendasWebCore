using Microsoft.EntityFrameworkCore;
using System.Data;
using VendasWebCore.Data;
using VendasWebCore.Models;
using VendasWebCore.Services.Exception;

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

        public void Insert(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Dep).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id)) 
            {
                throw new NotFoundException("Id não existe");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }

}
