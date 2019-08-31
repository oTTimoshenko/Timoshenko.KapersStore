using KapersStore.Domain.CartManagement;
using System.Collections.Generic;

namespace KapersStore.Domain.KaperManagement
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public int KaperId { get; set; }
        public Kaper Kaper { get; set; }

        public List<CartSubscription> CartSubscriptions { get; set; }

        public Subscription()
        {
            CartSubscriptions = new List<CartSubscription>();
        }
    }
}
