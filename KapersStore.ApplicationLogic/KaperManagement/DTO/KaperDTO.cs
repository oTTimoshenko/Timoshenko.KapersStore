using System.Collections.Generic;

namespace KapersStore.ApplicationLogic.KaperManagement.DTO
{
    public class KaperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string ImageAltText { get; set; }

        public List<SubscriptionDTO> Subscriptions { get; set; }
    }
}
