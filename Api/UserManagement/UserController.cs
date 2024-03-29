﻿using Api.Abstractions;
using Api.Configurations;
using Api.UserManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.UserManagement
{
    [Authorize]
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserAuthenticateModel userModel)
        {
            if (userModel is null)
                return BadRequest();

            var user = userService.Authenticate(userModel.Login, userModel.Password);

            if (user is null)
                return BadRequest(new { message = "Email or Password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecret = Encoding.ASCII.GetBytes(appSettings.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecret), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            //return only basic user info
            return Ok(new UserAuthenticateResultModel
            {
                Id = user.Id,
                Email = user.Email,
                Nickname = user.Nickname,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("registrate")]
        public IActionResult Registrate([FromBody]UserRegistrateModel userRegistrateModel)
        {
            if (userRegistrateModel is null)
                return BadRequest();

            var userRegistrateDto = mapper.Map<UserRegistrateDTO>(userRegistrateModel);
            try
            {
                userService.Registrate(userRegistrateDto);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("confirmEmail")]
        public IActionResult ConfirmEmail([FromBody]UserConfirmEmailModel confirmModel)
        {
            if (string.IsNullOrWhiteSpace(confirmModel.Email) || string.IsNullOrWhiteSpace(confirmModel.Code))
                return BadRequest();

            userService.ConfirmEmail(confirmModel.Email, confirmModel.Code);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("resetPassword")]
        public IActionResult ResetPassword([FromBody]UserResetPasswordModel resetModel)
        {
            if (!resetModel.Validate())
                return BadRequest();

            userService.ResetPassword(resetModel.Email, resetModel.Code, resetModel.NewPassword);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("resetPassword/request")]
        public IActionResult RequestResetPassword([FromBody]UserRequestResetPasswordModel requestResetModel)
        {
            if (string.IsNullOrWhiteSpace(requestResetModel.Email))
                return BadRequest();

            userService.RequestResetPasswordMail(requestResetModel.Email);

            return Ok();
        }
    }
}