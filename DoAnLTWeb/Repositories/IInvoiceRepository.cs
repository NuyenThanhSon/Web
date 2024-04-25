using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface IInvoiceRepository
    {

        Task<List<Invoice>> GetInvoicesByCustomerIdAsync(int customerId);
        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(int invoiceId);
    }
}
