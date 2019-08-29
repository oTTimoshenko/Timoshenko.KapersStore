using System.Collections.Generic;

namespace Api.KaperManagement.Models
{
    public class KaperModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string ImageAltText { get; set; }

        public List<SubscriptionModel> Subscriptions { get; set; }
    }
}
