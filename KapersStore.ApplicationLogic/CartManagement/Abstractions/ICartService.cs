using KapersStore.ApplicationLogic.CartManagement.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.CartManagement.Abstractions
{
    public interface ICartService
    {
        CartDTO GetUserCart(int userId);
        void CreateCart(CartCreateDTO cartDTO);
        void AddSubscriptionToUserCart(int userId, int subscriptionId);
        void RemoveSubscriptionFromUserCart(int userId, int subscriptionId, RemoveSubscriptionMode removeMode);
        void RemoveKaperSubscriptionsFromUserCart(int userId, int kaperId);
        void RemoveCart(int id);
    }
}
