using KapersStore.ApplicationLogic.UserManagement.DTO;
using System;
using System.Collections.Generic;

namespace KapersStore.ApplicationLogic.KaperManagement.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public CommentDTO Parent { get; set; }
        public List<CommentDTO> Childs { get; set; }

        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public int KaperId { get; set; }
        public KaperDTO Kaper { get; set; }
    }
}
