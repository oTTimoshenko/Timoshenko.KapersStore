using KapersStore.Domain.PurchaseManagement;
using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KapersStore.Domain.CartManagement
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<CartSubscription> CartSubscriptions { get; set; }

        public decimal TotalPrice => CartSubscriptions
                                        .Sum(cs => cs.SubscriptionsCount * cs.Subscription.Price);

        public Cart()
        {
            CartSubscriptions = new List<CartSubscription>();
        }
    }
}
