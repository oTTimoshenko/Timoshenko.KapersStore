using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.CartManagement
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<CartSubscription> CartSubscriptions { get; set; }

        public Cart()
        {
            CartSubscriptions = new List<CartSubscription>();
        }
    }
}
