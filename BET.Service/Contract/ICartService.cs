using BET.Data.Model;

namespace BET.Service.Contract
{
    public interface ICartService
    {
        Task<Cart> AddToCartAsync(Cart cart);
        Task<IList<Cart>> GetCartItemsAsync(int userId);
    }
}
