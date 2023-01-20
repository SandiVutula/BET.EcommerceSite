using BET.Data.Model;

namespace BET.Service.Contract
{
    public interface ICartService
    {
        void AddToCartAsync(Cart cart);
        Task<IList<Cart>> GetCartItemsAsync(int userId);
        Task<IList<Cart>> RemoveCartItem(int itemId);
    }
}
