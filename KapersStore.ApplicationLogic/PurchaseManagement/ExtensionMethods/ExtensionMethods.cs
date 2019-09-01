using KapersStore.ApplicationLogic.PurchaseManagement.DTO;
using KapersStore.Domain.PurchaseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KapersStore.ApplicationLogic.PurchaseManagement.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static PurchaseDTO ToPurchaseDto(this Purchase p) =>
            new PurchaseDTO
            {
                Id = p.Id,
                DateEnd = p.DateEnd,
                DatePaid = p.DatePaid,
                DateStart = p.DateStart,
                IsPaid = !p.DatePaid.HasValue,
                TotalPrice = p.TotalPrice,
                Subscriptions = p.PurchaseSubscriptions.Select(ps => ps.ToPurchaseSubscriptionDto())
            };

        public static PurchaseSubscriptionDTO ToPurchaseSubscriptionDto(this PurchaseSubscription ps) =>
            new PurchaseSubscriptionDTO
            {
                Count = ps.SubscriptionCount,
                TotalDays = ps.SubscriptionCount * ps.Subscription.Days,
                EndDate = ps.Purchase.DateEnd,
                IsActive = ps.Purchase.DateEnd < DateTime.UtcNow,
                KaperName = ps.Subscription.Kaper.Name,
                Name = ps.Subscription.Name,
                Price = ps.Subscription.Price,
                TotalPrice = ps.SubscriptionCount * ps.Subscription.Price,
                StartDate = ps.Purchase.DateStart,
                DaysLeft = ps.Purchase.DateEnd < DateTime.UtcNow || !ps.Purchase.DateEnd.HasValue
                                ? 0
                                : (ps.Purchase.DateEnd - DateTime.UtcNow).Value.Days
            };
    }
}
