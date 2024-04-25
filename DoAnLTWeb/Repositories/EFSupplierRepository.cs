using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFSupplierRepository : ISupplierRepository
    {
        private readonly CsdlwebContext _context;

        public EFSupplierRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            // return await _context.Categorys.ToListAsync();
            return await _context.Suppliers.ToListAsync(); // Include thông tin về category
        }


        public async Task<Supplier> GetByIdAsync(int id)
        {
            // return await _context.Categorys.FindAsync(id);
            return await _context.Suppliers.FirstOrDefaultAsync(p => p.Idsupplier == id);
        }


        public async Task AddAsync(Supplier Category)
        {
            _context.Add(Category);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Supplier Category)
        {
            _context.Update(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Suppliers.FirstAsync(p => p.Idsupplier == id);
            _context.Suppliers.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
