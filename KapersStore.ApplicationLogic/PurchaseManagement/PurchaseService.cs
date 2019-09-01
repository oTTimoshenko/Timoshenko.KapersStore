using AutoMapper;
using KapersStore.ApplicationLogic.PurchaseManagement.Abstractions;
using KapersStore.ApplicationLogic.PurchaseManagement.DTO;
using KapersStore.ApplicationLogic.PurchaseManagement.ExtensionMethods;
using KapersStore.DataAccess;
using KapersStore.Domain.ExtensionMethods;
using KapersStore.Domain.PurchaseManagement;
using KapersStore.Infrastructure.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KapersStore.ApplicationLogic.PurchaseManagement
{
    public class PurchaseService: IPurchaseService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public PurchaseService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public PurchaseDTO Create(PurchaseCreateDTO createDto)
        {
            var userCart = dataContext.Users.Get(createDto.UserId).Cart;

            var purchase = new Purchase
            {
                UserId = createDto.UserId,
                TotalPrice = userCart.TotalPrice,
                PurchaseSubscriptions = userCart.CartSubscriptions.ToPurchaseSubscriptions()
            };

            dataContext.Purchases.Add(purchase);
            dataContext.SaveChanges();

            return mapper.Map<PurchaseDTO>(purchase);
        }

        public IEnumerable<PurchaseDTO> GetUserPurchases(int userId)
        {
            var userPurchases = dataContext.Users.Get(userId).Purchases;

            var result = userPurchases.Select(p => p.ToPurchaseDto());

            return result;
        }

        public IEnumerable<PurchaseSubscriptionDTO> GetUserSubscriptions(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
