using BET.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Endpoints
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                //TODO: Still needs implementation
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            try
            {
                //TODO: Still needs implementation
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
