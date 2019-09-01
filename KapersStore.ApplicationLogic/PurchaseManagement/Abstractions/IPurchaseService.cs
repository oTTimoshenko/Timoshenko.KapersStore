using KapersStore.ApplicationLogic.PurchaseManagement.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.PurchaseManagement.Abstractions
{
    public interface IPurchaseService
    {
        PurchaseDTO Create(PurchaseCreateDTO createDto);
        IEnumerable<PurchaseDTO> GetUserPurchases(int userId);
        IEnumerable<PurchaseSubscriptionDTO> GetUserSubscriptions(int userId);
    }
}
