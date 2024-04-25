using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFWarehousedetailRepository : IWarehousedetailRepository
    {
        private readonly CsdlwebContext _context;

        public EFWarehousedetailRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehousedetail>> GetAllAsync()
        {
            // return await _context.Warehousedetails.ToListAsync();
            return await _context.Warehousedetails.Include(p => p.IdproductNavigation).Include(p=>p.IdwarehouseNavigation).ToListAsync();
        }
        public async Task<Warehousedetail> GetByIdAsync(int idp , int idW)
        {
            // return await _context.Warehousedetails.FindAsync(id);
            return await _context.Warehousedetails.Include(p => p.IdproductNavigation).Include(p => p.IdwarehouseNavigation)
            .FirstOrDefaultAsync(p => p.Idwarehouse == idp &&p.Idproduct==idW);
        }
        public async Task<IEnumerable<Warehousedetail>> GetAllProduct(int productId)
        {
            return await _context.Warehousedetails.Include(p => p.IdproductNavigation).Where(p => p.Idproduct  == productId).ToListAsync();
        } public async Task<IEnumerable<Warehousedetail>> GetAllWarehouse(int warehouseId)
        {
            return await _context.Warehousedetails.Include(p => p.IdwarehouseNavigation).Where(p => p.Idwarehouse  == warehouseId).ToListAsync();
        }
        public async Task AddAsync(Warehousedetail Warehousedetail)
        {
            _context.Warehousedetails.Add(Warehousedetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehousedetail Warehousedetail)
        {
            _context.Warehousedetails.Update(Warehousedetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Warehousedetail = await _context.Warehousedetails.FindAsync(id);
            _context.Warehousedetails.Remove(Warehousedetail);
            await _context.SaveChangesAsync();
        }

  
    }
}