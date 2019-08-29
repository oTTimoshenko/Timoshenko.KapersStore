namespace Api.KaperManagement.Models
{
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }

        public int KaperId { get; set; }
    }
}
