using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private readonly CsdlwebContext _context;

        public EFInvoiceRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetInvoicesByCustomerIdAsync(int customerId)
        {
            return await _context.Invoices
                                 .Where(i => i.Idcustomer == customerId)
                                 .ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }

        public async Task AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
