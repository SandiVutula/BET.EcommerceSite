using BET.Data.GenericRepository;
using BET.Data.Model;
using BET.Data.Model.Dto;
using BET.Service.Contract;

namespace BET.Service.Service
{
    public class CartService : ICartService
    {
        private readonly IRepository _iRepository;
        public CartService(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public async void AddToCartAsync(Cart cart)
        {
            if (cart != null)
            {
                _iRepository.Create<Cart>(cart);
            }
            await _iRepository.SaveAsync();
        }

        public async Task<IList<Cart>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _iRepository.GetAsync<Cart>(b => b.UserId == userId);
            return cartItems.ToList();
        }

        public async Task<IList<Cart>> RemoveCartItem(int itemId)
        {
            var cart = await _iRepository.GetAsync<Cart>();
            var cartItem = cart.FirstOrDefault(b => b.Id == itemId);
            if(cartItem != null)
            {
                _iRepository.Remove(cartItem);
                _iRepository.Update(cart);
            }
            return cart.ToList();
        }
    }
}
