using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.PurchaseManagement.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }

        public IEnumerable<PurchaseSubscriptionDTO> Subscriptions { get; set; }
    }
}
