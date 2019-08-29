using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.KaperManagement.DTO
{
    public class CommentCreateDTO
    {
                public int? ParentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int KaperId { get; set; }
    }
}
