using BET.Data.Model.Dto;

namespace BET.Service.Contract
{
    public interface ICartService
    {
        Task<CartItem> AddToCartAsync(CartItem cartItem);
        Task<IList<CartItem>> GetCartItemsAsync(int userId);
    }
}
