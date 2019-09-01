using System.Collections.Generic;

namespace Api.CartManagement.Models
{
    public class CartModel
    {
        public int Id { get; set; }

        public IEnumerable<CartKaperModel> Kapers { get; set; }
    }
}
