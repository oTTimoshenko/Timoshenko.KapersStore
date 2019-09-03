using Api.Abstractions;
using Api.CartManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.CartManagement.Abstractions;
using KapersStore.ApplicationLogic.CartManagement.DTO;
using KapersStore.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.CartManagement
{
    [Route("api/carts/user")]
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserCart(int userId) =>
            Ok(mapper.Map<CartModel>(cartService.GetUserCart(userId)));

        [HttpPost("addSubscription")]
        public IActionResult AddSubscriptionToUserCart([FromBody]AddSubscriptionModel addModel)
        {
            cartService.AddSubscriptionToUserCart(addModel.UserId, addModel.SubscriptionId);

            return Ok();
        }

        [HttpPost("removeSubscription")]
        public IActionResult RemoveSubscriptionFromUserCart([FromBody]RemoveSubscriptionModel removeModel)
        {
            if (removeModel is null)
                return BadRequest();

            cartService.RemoveSubscriptionFromUserCart(removeModel.UserId,
                removeModel.SubscriptionId, (RemoveSubscriptionMode)removeModel.RemoveMode);

            return Ok();
        }

        [HttpPost("removeKaperSubscriptions")]
        public IActionResult RemoveKaperSubscriptionsFromUserCart([FromBody]RemoveKaperSubscriptionsModel removeModel)
        {
            if (removeModel is null)
                return BadRequest();

            cartService.RemoveKaperSubscriptionsFromUserCart(removeModel.UserId, removeModel.KaperId);

            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveUserCart([FromBody]IdModel userIdModel)
        {
            if (userIdModel is null)
                return BadRequest();

            cartService.RemoveUserCart(userIdModel.Id);

            return Ok();
        }
    }
}