using Api.KaperManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.KaperManagement.Abstractions;
using KapersStore.ApplicationLogic.KaperManagement.DTO;
using KapersStore.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.KaperManagement
{
    [Route("api/kapers")]
    [AllowAnonymous]
    [ApiController]
    public class KaperController : ControllerBase
    {
        private readonly IKaperService kaperService;
        private readonly IMapper mapper;

        public KaperController(IKaperService kaperService, IMapper mapper)
        {
            this.kaperService = kaperService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var kaper = mapper.Map<KaperModel>(kaperService.GetById(id));

            if (kaper is null)
                return NotFound();

            return Ok(kaper);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var kapers = mapper.Map<List<KaperModel>>(kaperService.GetAll());

            if (kapers is null)
                kapers = new List<KaperModel>();

            return Ok(kapers);
        }

        [HttpGet("{kaperId}/subscriptions")]
        public IActionResult GetKaperSubscriptions(int kaperId)
        {
            var subscriptions = mapper.Map<List<SubscriptionModel>>(kaperService.GetSubscriptions(kaperId));

            if (subscriptions is null)
                subscriptions = new List<SubscriptionModel>();

            return Ok(subscriptions);
        }

        [HttpGet("{kaperId}/comments")]
        public IActionResult GetKaperComments(int kaperId)
        {
            var comments = mapper.Map<List<CommentModel>>(kaperService.GetComments(kaperId));

            return Ok(comments);
        }

        [HttpPost("addComment")]
        public IActionResult AddComment([FromBody]CommentCreateModel comment)
        {
            if (comment is null)
                return BadRequest();

            var commentToAdd = mapper.Map<CommentCreateDTO>(comment);

            var addedComment = kaperService.AddComment(commentToAdd);

            return Ok(mapper.Map<CommentModel>(addedComment));
        }

        [HttpPost("removeComment")]
        public IActionResult RemoveComment([FromBody]IdModel commentId)
        {
            if (commentId is null)
                return BadRequest();

            kaperService.RemoveComment(commentId.Id);

            return Ok();
        }
    }
}