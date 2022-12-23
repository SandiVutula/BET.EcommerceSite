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
        public async Task<IActionResult> AddToCart([FromBody] Cart cart)
        {
            try
            {
                if(cart == null) 
                {
                    return BadRequest();
                }
                else
                {
                    var result = await _cartService.AddToCartAsync(cart);
                    var response = new Cart
                    {
                        Id = result.Id,
                        ProductId= result.ProductId,
                        Quantity = result.Quantity,
                        Total= result.Total,
                    };

                    return Ok(response);
                }
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("cartitems")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            try
            {
                if (userId != null)
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

        #endregion
    }
}
