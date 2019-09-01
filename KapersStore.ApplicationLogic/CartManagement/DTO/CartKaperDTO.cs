using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.CartManagement.DTO
{
    public class CartKaperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CartSubscriptionDTO> Subscriptions { get; set; }
    }
}
