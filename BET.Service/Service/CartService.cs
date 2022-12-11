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

        public async Task<CartItem> AddToCartAsync(CartItem cartItem)
        {
            IEnumerable<CartItem> basketItems = await _iRepository.GetAsync<CartItem>(b => b.UserId == cartItem.UserId);

            _iRepository.Create(cartItem);
            await _iRepository.SaveAsync();
            return cartItem;
        }

        public async Task<IList<CartItem>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _iRepository.GetAsync<CartItem>(b => b.UserId == userId);
            cartItems = PopulateProductIntoCartItem(cartItems.ToList());
            return cartItems.ToList();
        }

        #region Private Methods
        private List<CartItem> PopulateProductIntoCartItem(List<CartItem> cartItems)
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
