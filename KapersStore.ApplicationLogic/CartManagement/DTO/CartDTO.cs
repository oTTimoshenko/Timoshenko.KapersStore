using KapersStore.Domain.CartManagement;
using System.Collections.Generic;
using System.Linq;

namespace KapersStore.ApplicationLogic.CartManagement.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }

        public IEnumerable<CartKaperDTO> Kapers { get; set; }

        public static CartDTO ComposeCartDTO(Cart cart)
        {
            var kapers = cart.CartSubscriptions
                            .GroupBy(cs => cs.Subscription.KaperId)
                            .Select(group => new CartKaperDTO
                            {
                                Id = group.Key,
                                Name = group.First().Subscription.Kaper.Name,
                                Subscriptions = group.Select(s => new CartSubscriptionDTO
                                {
                                    Id = s.Subscription.Id,
                                    Days = s.Subscription.Days,
                                    KaperId = s.Subscription.KaperId,
                                    Name = s.Subscription.Name,
                                    Price = s.Subscription.Price,
                                    Count = s.SubscriptionsCount
                                })
                            });

            return new CartDTO
            {
                Id = cart.Id,
                Kapers = kapers
            };
        }
    }


}
