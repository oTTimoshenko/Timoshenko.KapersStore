using KapersStore.Domain.CartManagement;
using KapersStore.Domain.PurchaseManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.UserManagement
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public List<Purchase> Purchases{ get; set; }

        public User()
        {
            Purchases = new List<Purchase>();
        }
    }
}
