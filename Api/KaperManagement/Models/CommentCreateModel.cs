namespace Api.KaperManagement.Models
{
    public class CommentCreateModel
    {
        public int? ParentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int KaperId { get; set; }
    }
}
