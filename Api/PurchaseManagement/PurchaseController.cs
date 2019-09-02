using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.PurchaseManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.PurchaseManagement.Abstractions;
using KapersStore.ApplicationLogic.PurchaseManagement.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.PurchaseManagement
{
    [Route("api/purchases")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        IPurchaseService purchaseService;
        IMapper mapper;

        public PurchaseController(IPurchaseService purchaseService, IMapper mapper)
        {
            this.purchaseService = purchaseService;
            //purchaseService.
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create(PurchaseCreateModel createModel)
        { 
            var createdPurchase = purchaseService.Create(mapper.Map<PurchaseCreateDTO>(createModel));

            return Ok(mapper.Map<PurchaseModel>(createdPurchase));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserPurchases(int userId)
        {
            var purchases = purchaseService.GetUserPurchases(userId);

            return Ok(mapper.Map<IEnumerable<PurchaseModel>>(purchases));
        }

        [HttpGet("user/{userId}/subscriptions")]
        public IActionResult GetUserSubscriptions(int userId)
        {
            var subscriptions = purchaseService.GetUserSubscriptions(userId);

            return Ok(mapper.Map<IEnumerable<PurchaseSubscriptionModel>>(subscriptions));
        }
    }
}