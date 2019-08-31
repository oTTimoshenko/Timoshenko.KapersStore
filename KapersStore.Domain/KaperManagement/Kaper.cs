using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.KaperManagement
{
    public class Kaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string ImageAltText { get; set; }

        public List<Subscription> Subscriptions { get; set; }
        public List<Comment> Comments { get; set; }

        public Kaper()
        {
            Subscriptions = new List<Subscription>();
            Comments = new List<Comment>();
        }
    }
}
