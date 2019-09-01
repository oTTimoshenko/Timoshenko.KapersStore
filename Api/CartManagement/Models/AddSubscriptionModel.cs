using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CartManagement.Models
{
    public class AddSubscriptionModel
    {
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
    }
}
