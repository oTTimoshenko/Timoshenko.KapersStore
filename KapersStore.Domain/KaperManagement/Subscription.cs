using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.KaperManagement
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public int KaperId { get; set; }
        public Kaper Kaper { get; set; }
    }
}
