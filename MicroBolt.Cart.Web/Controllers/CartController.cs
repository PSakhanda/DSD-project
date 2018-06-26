using Microsoft.AspNetCore.Mvc;
using MicroBolt.Cart.Models;
using System.Net;
using System.Threading.Tasks;

using MicroBolt.Cart.MessageBus;

namespace MicroBolt.Cart.Web.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        // GET /id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var cart = await _repository.GetCartAsync(id);
            if (cart == null)
            {
                return Ok(new CustomerCart(id) { });
            }

            return Ok(cart);
        }

        // POST /value
        [HttpPost]
        [ProducesResponseType(typeof(CustomerCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]CustomerCart value)
        {
            var cart = await _repository.UpdateCartAsync(value);

            return Ok(cart);
        }

        [Route("checkout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public void Checkout([FromBody]CustomerCart value)
        {
            var userId = value.BuyerId;
            var MsgBus = new CheckoutMsg();
            MsgBus.Send(value);
            _repository.DeleteCartAsync(userId);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteCartAsync(id);
        }
    }
}
