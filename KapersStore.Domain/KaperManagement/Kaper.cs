using KapersStore.Infrastructure.Helpers.LocalizationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.KaperManagement
{
    public class Kaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionRU { get; set; }
        public string DescriptionUA { get; set; }
        public string ImageSource { get; set; }
        public string ImageAltText { get; set; }

        public List<Subscription> Subscriptions { get; set; }
        public List<Comment> Comments { get; set; }

        public string Description => LocalizationState.Locale == Locale.RU ? DescriptionRU : DescriptionUA;

        public Kaper()
        {
            Subscriptions = new List<Subscription>();
            Comments = new List<Comment>();
        }
    }
}
