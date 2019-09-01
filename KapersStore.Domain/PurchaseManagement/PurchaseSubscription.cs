using KapersStore.Domain.KaperManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.PurchaseManagement
{
    public class PurchaseSubscription
    {
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription{ get; set; }

        public int SubscriptionCount { get; set; }
        public decimal SubscriptionPrice { get; set; }
    }
}
