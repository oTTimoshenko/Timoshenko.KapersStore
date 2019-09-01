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
    [ApiController]
    public class CartController : ControllerBase
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
        public IActionResult AddSubscriptionToUserCart(AddSubscriptionModel addModel)
        {
            cartService.AddSubscriptionToUserCart(addModel.UserId, addModel.SubscriptionId);

            return Ok();
        }

        [HttpPost("removeSubscription")]
        public IActionResult RemoveSubscriptionFromUserCart(RemoveSubscriptionModel removeModel)
        {
            cartService.RemoveSubscriptionFromUserCart(removeModel.UserId,
                removeModel.SubscriptionId, (RemoveSubscriptionMode)removeModel.RemoveMode);

            return Ok();
        }

        [HttpPost("removeKaperSubscriptions")]
        public IActionResult RemoveKaperSubscriptionsFromUserCart(RemoveKaperSubscriptionsModel removeModel)
        {
            cartService.RemoveKaperSubscriptionsFromUserCart(removeModel.UserId, removeModel.KaperId);

            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveUserCart(IdModel userIdModel)
        {
            cartService.RemoveUserCart(userIdModel.Id);

            return Ok();
        }
    }
}