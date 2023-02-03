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

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public  async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Dep).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            if(!await _context.Vendedor.AnyAsync(x => x.Id == obj.Id)) 
            {
                throw new NotFoundException("Id não existe");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }

}
