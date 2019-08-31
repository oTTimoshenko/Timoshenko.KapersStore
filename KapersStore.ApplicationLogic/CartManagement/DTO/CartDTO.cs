using KapersStore.ApplicationLogic.KaperManagement.DTO;
using System.Collections.Generic;

namespace KapersStore.ApplicationLogic.CartManagement.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }

        public List<SubscriptionDTO.AddToCartDTO> Subscriptions { get; set; }
    }
}
