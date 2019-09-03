using KapersStore.Domain.CartManagement;
using KapersStore.Domain.PurchaseManagement;
using KapersStore.Infrastructure.Helpers.LocalizationService;
using System.Collections.Generic;

namespace KapersStore.Domain.KaperManagement
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionRU { get; set; }
        public string DescriptionUA { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public int KaperId { get; set; }
        public Kaper Kaper { get; set; }

        public List<CartSubscription> CartSubscriptions { get; set; }
        public List<PurchaseSubscription> PurchaseSubscriptions { get; set; }

        public string Description => LocalizationState.Locale == Locale.RU ? DescriptionRU : DescriptionUA;

        public Subscription()
        {
            CartSubscriptions = new List<CartSubscription>();
            PurchaseSubscriptions = new List<PurchaseSubscription>();
        }
    }
}
