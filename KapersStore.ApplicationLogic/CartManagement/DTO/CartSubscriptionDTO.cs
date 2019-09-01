using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.CartManagement.DTO
{
    public class CartSubscriptionDTO
    {
        public int Id { get; set; }
        public int KaperId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
    }
}
