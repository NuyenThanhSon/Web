using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFProductTypeRepository : IProductTypeRepository
    {
        private readonly CsdlwebContext _context;

        public EFProductTypeRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            // return await _context.Categorys.ToListAsync();
            return await _context.ProductTypes.ToListAsync(); // Include thông tin về category
        }


        public async Task<ProductType> GetByIdAsync(int id)
        {
            // return await _context.Categorys.FindAsync(id);
            return await _context.ProductTypes.FirstOrDefaultAsync(p => p.IdproductType == id);
        }


        public async Task AddAsync(ProductType Category)
        {
            _context.Add(Category);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(ProductType Category)
        {
            _context.Update(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.ProductTypes.FirstAsync(p => p.IdproductType == id);
            _context.ProductTypes.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}

