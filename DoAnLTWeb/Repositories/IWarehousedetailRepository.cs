using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface IWarehousedetailRepository
    {
        Task<IEnumerable<Warehousedetail>> GetAllAsync();
        Task<Warehousedetail> GetByIdAsync(int idp,int idW);
        Task<IEnumerable<Warehousedetail>> GetAllProduct(int productId);
        Task<IEnumerable<Warehousedetail>> GetAllWarehouse(int warehouseId);
        Task AddAsync(Warehousedetail product);
        Task UpdateAsync(Warehousedetail product);
        Task DeleteAsync(int id);
    }
}