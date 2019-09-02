using System;
using System.Collections.Generic;

namespace Api.PurchaseManagement.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }

        public IEnumerable<PurchaseSubscriptionModel> Subscriptions { get; set; }
    }
}
