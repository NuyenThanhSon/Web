using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task AddAsync(Supplier category);
        Task UpdateAsync(Supplier category);
        Task DeleteAsync(int id);
    }
}
