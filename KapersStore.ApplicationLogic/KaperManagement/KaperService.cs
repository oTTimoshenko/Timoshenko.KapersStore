using AutoMapper;
using KapersStore.ApplicationLogic.KaperManagement.Abstractions;
using KapersStore.ApplicationLogic.KaperManagement.DTO;
using KapersStore.DataAccess;
using KapersStore.Domain.KaperManagement;
using KapersStore.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KapersStore.ApplicationLogic.KaperManagement
{
    public class KaperService : IKaperService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public KaperService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            MethodToRemove();
        }

        private void MethodToRemove()
        {
            foreach (var kaper in dataContext.Kapers)
            {
                if(kaper.Subscriptions is null || !kaper.Subscriptions.Any())
                    kaper.Subscriptions = dataContext.Subscriptions.Where(s => s.KaperId == kaper.Id).ToList();
            }
            dataContext.SaveChanges();
        }

        public List<KaperDTO> GetAll() =>
            mapper.Map<List<KaperDTO>>(dataContext.Kapers.ToList());

        public KaperDTO GetById(int id) =>
            mapper.Map<KaperDTO>(dataContext.Kapers.Get(id));

        //public List<SubscriptionDTO> GetAllSubscriptions() =>
        //    mapper.Map<List<SubscriptionDTO>>(dataContext.Subscriptions.ToList());

        public SubscriptionDTO GetSubscriptionById(int id) =>
            mapper.Map<SubscriptionDTO>(dataContext.Subscriptions.Get(id));

        public List<SubscriptionDTO> GetSubscriptions(int kaperId) =>
            GetById(kaperId).Subscriptions;

        public List<CommentDTO> GetComments(int kaperId)
        {
            var comments = dataContext.Comments
                                        .Include(comment => comment.User)
                                        .Where(comment => comment.KaperId == kaperId);

            if (comments is null || !comments.Any())
                return new List<CommentDTO>();

            return mapper.Map<List<CommentDTO>>(comments);
        }

        public CommentDTO AddComment(CommentCreateDTO comment)
        {
            if (comment is null)
                throw new ArgumentNullException("Comment is null", nameof(comment));

            var commentEntity = new Comment
            {
                KaperId = comment.KaperId,
                ParentId = comment.ParentId,
                Text = comment.Text,
                UserId = comment.UserId,
                Date = DateTime.UtcNow
            };

            dataContext.Comments.Add(commentEntity);

            dataContext.SaveChanges();

            return mapper.Map<CommentDTO>(commentEntity);
        }

        public void RemoveComment(int commentId)
        {
            var comment = dataContext.Comments
                            .Include(c => c.Children)
                            .SingleOrDefault(c => c.Id == commentId);

            if (comment is null)
                throw new ArgumentException("Comment with id specified not found", nameof(commentId));


            dataContext.Comments.RemoveRange(comment.Children);
            dataContext.Comments.Remove(comment);
            dataContext.SaveChanges();
        }
    }
}
