using DoAnLTWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLTWeb.Repositories
{
    public class EFCartRepository : ICartRepository
    {
        private readonly CsdlwebContext _context;

        public EFCartRepository(CsdlwebContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int productId, int quantity, string username)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
            if (customer == null) throw new Exception("Không tìm thấy khách hàng");

            var cart = await _context.ShoppingCarts
                                     .Include(c => c.ShoppingCartDeltails)
                                     .FirstOrDefaultAsync(c => c.Idcustomer == customer.Idcustomer);

            if (cart == null)
            {
                cart = new ShoppingCart { Idcustomer = customer.Idcustomer };
                _context.ShoppingCarts.Add(cart);
            }

            var cartDetail = cart.ShoppingCartDeltails.FirstOrDefault(cd => cd.Idproduct == productId);
            if (cartDetail == null)
            {
                cartDetail = new ShoppingCartDeltail { Idproduct = productId, Quantity = quantity };
                cart.ShoppingCartDeltails.Add(cartDetail);
            }
            else
            {
                cartDetail.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCart(int cartItemId, int quantity)
        {
            if (quantity <= 0)
            {
                await RemoveFromCart(cartItemId);
                return;
            }

            var cartDetail = await _context.ShoppingCartDeltails.FindAsync(cartItemId);
            if (cartDetail != null)
            {
                cartDetail.Quantity = quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCart(int cartItemId)
        {
            var cartDetail = await _context.ShoppingCartDeltails.FindAsync(cartItemId);
            if (cartDetail != null)
            {
                _context.ShoppingCartDeltails.Remove(cartDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShoppingCart> GetCartByUsername(string username)
        {
            return await _context.ShoppingCarts
                .Include(c => c.ShoppingCartDeltails)
                    .ThenInclude(d => d.IdproductNavigation)
                .FirstOrDefaultAsync(c => c.IdcustomerNavigation.Username == username);
        }

    }
}
