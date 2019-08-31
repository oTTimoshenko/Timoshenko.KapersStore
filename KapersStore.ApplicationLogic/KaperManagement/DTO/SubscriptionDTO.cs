namespace KapersStore.ApplicationLogic.KaperManagement.DTO
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public int KaperId { get; set; }

        public class AddToCartDTO
        {
            public int SubscriptionId { get; set; }
            public int Count { get; set; }
        }
    }
}
