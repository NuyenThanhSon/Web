using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllSale();
        Task<IEnumerable<Product>> GetAllProductType(int id);
        Task<IEnumerable<Product>> GetAllSuppelier(int id);
        Task<Product> GetByIdAsync(int id);

        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}