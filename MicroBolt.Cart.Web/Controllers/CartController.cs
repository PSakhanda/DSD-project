using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using MicroBolt.Cart.Web.EventBus.Events;
using MicroBolt.Cart.Web.Model;
using MicroBolt.Cart.Web.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MicroBolt.Cart.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;
        private readonly IIdentityService _identitySvc;
        //private readonly IEventBus _eventBus;

        public CartController(ICartRepository repository,
            IIdentityService identityService)
            //IEventBus eventBus)
        {
            _repository = repository;
            _identitySvc = identityService;
            //_eventBus = eventBus;
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
        public async Task<IActionResult> Checkout([FromBody]CartCheckout cartCheckout, [FromHeader(Name = "x-requestid")] string requestId)
        {
            var userId = _identitySvc.GetUserIdentity();
            var userName = User.FindFirst(x => x.Type == "unique_name").Value;

            cartCheckout.RequestId = (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty) ?
                guid : cartCheckout.RequestId;

            var cart = await _repository.GetCartAsync(userId);

            if (cart == null)
            {
                return BadRequest();
            }

            var eventMessage = new UserCheckoutAcceptedIntegrationEvent(userId, userName, cartCheckout.City, cartCheckout.Street,
                cartCheckout.State, cartCheckout.Country, cartCheckout.ZipCode, cartCheckout.CardNumber, cartCheckout.CardHolderName,
                cartCheckout.CardExpiration, cartCheckout.CardSecurityNumber, cartCheckout.CardTypeId, cartCheckout.Buyer, cartCheckout.RequestId, cart);

            // Once cart is checkout, sends an integration event to
            // ordering.api to convert cart to order and proceeds with
            // order creation process
            //_eventBus.Publish(eventMessage);

            return Accepted();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteCartAsync(id);
        }
    }
}
