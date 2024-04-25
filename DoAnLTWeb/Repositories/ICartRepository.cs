using DoAnLTWeb.Models;

namespace DoAnLTWeb.Repositories
{
    public interface ICartRepository
    {
        Task AddToCart(int productId, int quantity, string username);
        Task UpdateCart(int cartItemId, int quantity);
        Task RemoveFromCart(int cartItemId);
        Task<ShoppingCart> GetCartByUsername(string username);
    }
}
