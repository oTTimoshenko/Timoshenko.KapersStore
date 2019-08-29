using System;

namespace Api.KaperManagement.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserNickname { get; set; }
        public int KaperId { get; set; }
    }
}
