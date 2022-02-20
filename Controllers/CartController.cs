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
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;
        private readonly ICartService _service;
        private readonly ICartItemApplication _application;

        public CartController(ILogger<CartController> logger, ICartService service, ICartItemApplication application)
        {
            _logger = logger;
            _service = service;
            _application = application;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _service.GetAllCarts();
            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CartItemRequest cart)
        {
            var response = await _application.AddToCart(cart);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);
           
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _application.RemoveToCart(id);
            if (response.ValidationErrors.Any())
                return UnprocessableEntity(response.ValidationErrors);

            return Ok(response);
        }
    }
}
