using KapersStore.Domain.CartManagement;
using KapersStore.Domain.PurchaseManagement;
using System.Collections.Generic;
using System.Linq;

namespace KapersStore.Domain.ExtensionMethods
{
    public static class CartSubscriptionExtensionMethods
    {
        public static List<PurchaseSubscription> ToPurchaseSubscriptions(this List<CartSubscription> cartSubscriptions) =>
            cartSubscriptions.Select(cs => cs.ToPurchaseSubscription()).ToList();

        public static PurchaseSubscription ToPurchaseSubscription(this CartSubscription cartSubscription) =>
            new PurchaseSubscription
            {
                Subscription = cartSubscription.Subscription,
                SubscriptionPrice = cartSubscription.Subscription.Price,
                SubscriptionCount = cartSubscription.SubscriptionsCount
            };
    }
}
