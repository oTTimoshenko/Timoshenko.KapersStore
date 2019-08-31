using AutoMapper;
using KapersStore.ApplicationLogic.CartManagement.Abstractions;
using KapersStore.ApplicationLogic.CartManagement.DTO;
using KapersStore.DataAccess;
using KapersStore.Domain.CartManagement;
using KapersStore.Infrastructure.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KapersStore.ApplicationLogic.CartManagement
{
    public class CartService : ICartService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public CartService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        #region Public Methods

        public CartDTO GetUserCart(int userId)
        {
            var user = dataContext.Users.Get(userId);
            var cart = user.Cart;

            if (cart is null)
                CreateCart(new CartCreateDTO { UserId = userId });

            return mapper.Map<CartDTO>(cart);
        }

        public void AddSubscriptionToUserCart(int userId, int subscriptionId) =>
            AddRemoveSubscriptionOfUserCart(userId, subscriptionId, AddRemoveOption.Add, null);

        public void RemoveSubscriptionFromUserCart(int userId, int subscriptionId, RemoveSubscriptionMode removeMode) =>
            AddRemoveSubscriptionOfUserCart(userId, subscriptionId, AddRemoveOption.Remove, removeMode);

        public void RemoveKaperSubscriptionsFromUserCart(int userId, int kaperId)
        {
            var kaper = dataContext.Kapers.Get(kaperId);

            var cartSubscriptions = GetCartSubscriptionListByUser(userId, kaper.Subscriptions.Select(s => s.Id), out Cart cart);

            dataContext.CartSubscriptions.RemoveRange(cartSubscriptions);
            dataContext.SaveChanges();
        }

        public void CreateCart(CartCreateDTO cartDTO)
        {
            if (cartDTO is null)
                throw new ArgumentNullException(nameof(cartDTO));

            var user = dataContext.Users.Get(cartDTO.UserId);

            var cart = new Cart { User = user };

            dataContext.Carts.Add(cart);
            dataContext.SaveChanges();
        }

        public void RemoveCart(int id)
        {
            var cart = dataContext.Carts.Get(id);

            dataContext.Carts.Remove(cart);
            dataContext.SaveChanges();
        }

        #endregion

        #region Private Methods

        private void AddRemoveSubscriptionOfUserCart(int userId, int subscriptionId, AddRemoveOption addRemoveOption, RemoveSubscriptionMode? removeMode)
        {
            var cartSubscription = GetCartSubscriptionByUser(userId, subscriptionId, out Cart cart);

            if (cartSubscription is null && addRemoveOption == AddRemoveOption.Remove)
                throw new ArgumentException("CartSubscription was not found", nameof(cartSubscription));

            if (addRemoveOption == AddRemoveOption.Add)
                AddToCart();
            else
                RemoveFromCart();

            dataContext.SaveChanges();

            #region Local Functions

            void AddToCart()
            {
                if (cartSubscription is null)
                {
                    cartSubscription = new CartSubscription { Cart = cart, SubscriptionId = subscriptionId };
                    dataContext.CartSubscriptions.Add(cartSubscription);
                }
                else
                {
                    cartSubscription.SubscriptionsCount++;
                    dataContext.CartSubscriptions.Update(cartSubscription);
                }
            }

            void RemoveFromCart()
            {
                if (removeMode == RemoveSubscriptionMode.ItemCompletely)
                    dataContext.CartSubscriptions.Remove(cartSubscription);
                else
                {
                    cartSubscription.SubscriptionsCount--;
                    dataContext.CartSubscriptions.Update(cartSubscription);
                }
            }

            #endregion
        }

        private CartSubscription GetCartSubscriptionByUser(int userId, int subscriptionId, out Cart cart) =>
            GetCartSubscriptionListByUser(userId, new int[] { subscriptionId }, out cart).FirstOrDefault();

        private List<CartSubscription> GetCartSubscriptionListByUser(int userId, IEnumerable<int> subscriptionIds, out Cart cart)
        {
            var user = dataContext.Users.Get(userId);

            cart = user.Cart;

            var subscriptions = dataContext.Subscriptions.Where(s => subscriptionIds.Contains(s.Id));

            return dataContext
                    .CartSubscriptions
                    .Where(cs => subscriptionIds.Contains(cs.SubscriptionId) && cs.CartId == user.CartId)
                    .ToList();
        }

        #endregion
    }
}
