using ComicStore.Application.Contracts.Request;
using ComicStore.Application.Interface;
using ComicStore.Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {

        private readonly ILogger<ShoppingCartController> _logger;
        private readonly ICartItemApplication _application;

        public ShoppingCartController(ILogger<ShoppingCartController> logger, ICartItemApplication application)
        {
            _logger = logger;
            _application = application;
        }
        // GET: /cart
        /// <summary>
        /// Get All Carts
        /// </summary>
        /// <returns></returns>
        [HttpGet("/cart")]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _application.GetAllCarts();
            return Ok(carts);
        }

        // POST: /cart
        /// <summary>
        /// Add one Cart
        /// </summary>
        /// <param name="CartItemRequest"></param>
        /// <returns></returns>

        [HttpPost("/cart")]
        public async Task<IActionResult> AddCart([FromBody] CartItemRequest cart)
        {
            var response = await _application.AddToCart(cart);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);
           
            return Ok(response);
        }

        // PUT: /cart
        /// <summary>
        /// Update one cart
        /// </summary>
        /// <param name="UpdateCartItemRequest"></param>
        /// <returns></returns>
        [HttpPut("/cart")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemRequest cart)
        {
            var response = await _application.UpdateCart(cart);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);

            return Ok(response);
        }

        // DELETE: /cart
        /// <summary>
        /// Remove one cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/cart/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _application.RemoveToCart(id);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);

            return Ok(response);
        }

        // GET: /order
        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/order")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _application.GetAllOrders();
            return Ok(orders);
        }

        // POST: /order
        /// <summary>
        /// Add one Order
        /// </summary>
        /// <param name="OrderRequest"></param>
        /// <returns></returns>
        [HttpPost("/order")]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequest order)
        {
            var response = await _application.AddToOrder(order);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);

            return Ok(response);
        }

    }
}
