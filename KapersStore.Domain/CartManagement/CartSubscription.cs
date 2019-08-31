using KapersStore.Domain.KaperManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.CartManagement
{
    public class CartSubscription
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public int SubscriptionsCount { get; set; } = 0;
    }
}
