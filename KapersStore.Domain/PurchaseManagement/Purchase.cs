using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.PurchaseManagement
{
    public class Purchase
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User{ get; set; }

        public DateTime? DatePaid { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public decimal TotalPrice { get; set; }

        public List<PurchaseSubscription> PurchaseSubscriptions { get; set; }

        public Purchase()
        {
            PurchaseSubscriptions = new List<PurchaseSubscription>();
        }
    }
}
