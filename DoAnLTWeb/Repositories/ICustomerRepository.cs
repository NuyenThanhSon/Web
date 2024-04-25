using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> FindByUsernameAsync(string username);

        Task<Customer> FindByIdAsync(int idcustomer);

        Task UpdateAsync(Customer customer);

    }
}
