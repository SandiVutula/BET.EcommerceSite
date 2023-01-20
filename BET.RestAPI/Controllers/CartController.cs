using BET.Data.Model;
using BET.Data.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        #region Constructor 
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        #endregion

        #region Endpoints
        [HttpPost]
        [Route("addtocart")]
        public Task<IActionResult> AddToCart([FromBody] Cart cart)
        {
            try
            {
                if(cart == null) 
                {
                    return Task.FromResult<IActionResult>(new NotFoundResult());
                }
                else
                {
                    _cartService.AddToCartAsync(cart);
                    return Task.FromResult<IActionResult>(new OkResult());
                }
            }
            catch (Exception ex)
            {
               return Task.FromResult<IActionResult>(new BadRequestResult());
            }
        }

        [HttpGet]
        [Route("cartitems")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            try
            {
                if (userId != 0)
                {
                    var result = await _cartService.GetCartItemsAsync(userId);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removeCartItem/{itemId}")]
        public async Task<IActionResult> RemoveItemFromCart(int itemId)
        {
            try
            {
                if (itemId != 0)
                {
                   await _cartService.RemoveCartItem(itemId);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Item has been successfully removed");
        }

        #endregion
    }
}
