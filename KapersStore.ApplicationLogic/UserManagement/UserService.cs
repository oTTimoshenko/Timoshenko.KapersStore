﻿using AutoMapper;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.DataAccess;
using KapersStore.Domain.UserManagement;
using KapersStore.Infrastructure.Exceptions;
using KapersStore.Infrastructure.ExtensionMethods;
using System;
using System.Linq;
using System.Text;

namespace KapersStore.ApplicationLogic.UserManagement
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UserService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public UserDTO Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = GetUserByEmail(email);

            if (user is null) return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return mapper.Map<UserDTO>(user);
        }

        public void Registrate(UserRegistrateDTO userData)
        {
            userData.Validate();

            if (dataContext.Users.Any(u => u.Nickname.Equals(userData.Nickname)))
                throw new ValidationException($"Username {userData.Nickname} is already taken");

            CreatePasswordHash(userData.Password, out byte[] passwordHash, out byte[] passwordSalt);

            dataContext.Users.Add(new User()
            {
                Nickname = userData.Nickname,
                Email = userData.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            dataContext.SaveChanges();
        }

        public UserDTO GetById(int id) =>
            mapper.Map<UserDTO>(dataContext.Users.Get(id));


        private User GetUserByEmail(string email) =>
            dataContext.Users.SingleOrDefault(user => user.Email.Equals(email));

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value can not be empty.", nameof(password));
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != storedHash[i]) return false;
            }

            return true;
        }
    }
}
