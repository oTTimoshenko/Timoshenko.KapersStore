using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;

namespace KapersStore.Domain.KaperManagement
{
    public class Comment
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public Comment Parent { get; set; }
        public List<Comment> Children { get; set; }

        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int KaperId { get; set; }
        public Kaper Kaper { get; set; }

        public Comment()
        {
            Children = new List<Comment>();
        }
    }
}
