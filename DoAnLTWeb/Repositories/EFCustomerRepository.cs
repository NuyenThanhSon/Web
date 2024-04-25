using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly CsdlwebContext _context;

        public EFCustomerRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> FindByUsernameAsync(string username)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task<Customer> FindByIdAsync(int idcustomer)
        {
            return await _context.Customers
                                 .Include(c => c.Invoices) // Optional, include related data as needed
                                 .FirstOrDefaultAsync(c => c.Idcustomer == idcustomer);
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }



    }
}
