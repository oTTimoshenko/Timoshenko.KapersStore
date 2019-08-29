using KapersStore.ApplicationLogic.KaperManagement.DTO;
using System.Collections.Generic;

namespace KapersStore.ApplicationLogic.KaperManagement.Abstractions
{
    public interface IKaperService
    {
        KaperDTO GetById(int id);
        List<KaperDTO> GetAll();

        SubscriptionDTO GetSubscriptionById(int id);
        List<SubscriptionDTO> GetSubscriptions(int kaperId);
        //List<SubscriptionDTO> GetAllSubscriptions();

        List<CommentDTO> GetComments(int kaperId);
        CommentDTO AddComment(CommentCreateDTO comment);
        void RemoveComment(int commentId);
    }
}
