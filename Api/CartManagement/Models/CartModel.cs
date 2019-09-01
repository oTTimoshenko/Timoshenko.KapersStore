using System.Collections.Generic;

namespace Api.CartManagement.Models
{
    public class CartModel
    {
        public int Id { get; set; }

        public List<SubscriptionModel> Subscriptions { get; set; }

        public class SubscriptionModel
        {
            public int SubscriptionId { get; set; }
            public int Count { get; set; }
        }
    }
}
