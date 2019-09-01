using KapersStore.ApplicationLogic.CartManagement.DTO;

namespace Api.CartManagement.Models
{
    public class RemoveSubscriptionModel
    {
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public int RemoveMode { get; set; }
    }
}
