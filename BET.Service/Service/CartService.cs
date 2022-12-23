using BET.Data.GenericRepository;
using BET.Data.Model;
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

        public async Task<Cart> AddToCartAsync(Cart cart)
        {
            IEnumerable<Cart> baskets = await _iRepository.GetAsync<Cart>(b => b.UserId == cart.UserId);

            _iRepository.Create(cart);
            await _iRepository.SaveAsync();
            return cart;
        }

        public async Task<IList<Cart>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _iRepository.GetAsync<Cart>(b => b.UserId == userId);
            cartItems = PopulateProductIntoCartItem(cartItems.ToList());
            return cartItems.ToList();
        }

        #region Private Methods
        private List<Cart> PopulateProductIntoCartItem(List<Cart> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                cartItem.Product = _iRepository.GetById<Product>(cartItem.ProductId);
            }

            return cartItems;
        }

        #endregion
    }
}
