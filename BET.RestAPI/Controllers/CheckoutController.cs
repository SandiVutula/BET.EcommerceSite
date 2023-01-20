using BET.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        #region Constructor 
        public CheckoutController(IOrderService orderService, IUserService userService, IEmailService emailService)
        {
            _orderService = orderService;
            _userService = userService;
            _emailService = emailService;
        }
        #endregion

        [Authorize]
        [HttpPost]
        public IActionResult SaveOrder(Order order)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var jwtSecurityToken = new JwtSecurityToken(token);
            var userId = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;

            var user = _userService.GetUserById(Int32.Parse(userId));

            order.UserId = user.Id;
            _orderService.SaveOrder(order);

            string emailBody = $@"
                                <html>
                                    <body>
                                        <h1>Order Confirmation</h1>
                                        <p>Dear {user.FirstName},</p>
                                        <p>Thank you for your order! We have received your order and it is now being processed.</p>
                                        <h2>Order Details:</h2>
                                        <ul>
                                            <li>Order Number: {order.OrderNumber}</li>
                                            <li>Order Date: {order.OrderDate.ToString()}</li>
                                        </ul>
                                        <h2>Items:</h2>
                                        <ul>
                                            {string.Join(string.Empty, order.CartItems.Select(x => $"<li>{x.ProductId} ({x.Quantity}) - R{x.Total}</li>"))}
                                        </ul>
                                        <p>Total: R{order.TotalPrice}</p>
                                        <p>Please keep this email as a reference for your records.</p>
                                        <p>Thank you for choosing BET products,</p>
                                        <p>The BET Team</p>
                                    </body>
                                </html>";

            _emailService.SendEmailMessage(user.Email, "Order Confirmation - Order #" + order.OrderNumber, emailBody);

            return Ok();
        }
    }
}
