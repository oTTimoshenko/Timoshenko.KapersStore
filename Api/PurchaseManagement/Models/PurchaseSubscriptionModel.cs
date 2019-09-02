using System;

namespace Api.PurchaseManagement.Models
{
    public class PurchaseSubscriptionModel
    {
        public string KaperName { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int TotalDays { get; set; }
        public int DaysLeft { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
