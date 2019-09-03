using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.MailManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.MailManagement.Abstractions;
using KapersStore.ApplicationLogic.MailManagement.DTO;
using KapersStore.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.MailManagement
{
    [Route("api/mails")]
    [ApiController]
    [Authorize]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly IMapper mapper;

        public MailController(IMailService mailService, IMapper mapper)
        {
            this.mailService = mailService;
            this.mapper = mapper;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserMails(int userId) =>
            Ok(mapper.Map<MailModel>(mailService.GetUserMails(userId)));

        [HttpGet]
        public IActionResult GetAllMails() =>
            Ok(mapper.Map<MailModel>(mailService.GetAllMails()));

        [HttpGet("ofDate")]
        public IActionResult GetMailsByDate(DateModel dateModel)=>
            Ok(mapper.Map<MailModel>(mailService.GetMailsByDate(dateModel.DateTime)));

        [HttpGet("todays")]
        public IActionResult GetTodaysMails()=>
            Ok(mapper.Map<MailModel>(mailService.GetTodaysMails()));

        [HttpPost("sendToUsers")]
        public IActionResult SendMailToUsers([FromBody]MailSendModel sendModel)
        {
            mailService.SendMailToUsers(mapper.Map<MailSendDTO>(sendModel));

            return Ok();
        }
    }
}