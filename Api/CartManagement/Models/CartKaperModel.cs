using System.Collections.Generic;

namespace Api.CartManagement.Models
{
    public class CartKaperModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CartSubscriptionModel> Subscriptions { get; set; }
    }
}
