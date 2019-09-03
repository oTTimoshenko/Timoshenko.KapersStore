namespace Api.MailManagement.Models
{
    public class MailSubscriptionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KaperId { get; set; }
        public string KaperName { get; set; }
    }
}
