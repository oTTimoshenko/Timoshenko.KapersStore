using AutoMapper;
using KapersStore.ApplicationLogic.MailManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement.Abstractions;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.DataAccess;
using KapersStore.Domain.UserManagement;
using KapersStore.Infrastructure.Exceptions;
using KapersStore.Infrastructure.ExtensionMethods;
using KapersStore.Infrastructure.Helpers.PasswordGenerator;
using System;
using System.Linq;
using System.Text;

namespace KapersStore.ApplicationLogic.UserManagement
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IMailService mailService;

        public UserService(DataContext dataContext, IMapper mapper, IMailService mailService)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.mailService = mailService;
        }

        public UserDTO Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = FindUserByEmail(email);

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

            string userCode = PasswordGenerator.Generate(10, 0);

            dataContext.Users.Add(new User()
            {
                Nickname = userData.Nickname,
                Email = userData.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsConfirmed = false,
                Code = userCode
            });

            dataContext.SaveChanges();

            SendConfirmationMail(userData.Email, userCode);
        }

        public void ConfirmEmail(string email, string code)
        {
            var user = FindUserByEmail(email);

            if (user is null || !user.Code.Equals(code))
                throw new ArgumentException("Something went wrong");

            user.Confirm();

            dataContext.SaveChanges();
        }

        public void ResetPassword(string email, string userCode, string newPassword)
        {
            var user = dataContext.Users.FirstOrDefault(u => u.Email.Equals(email) && u.Code.Equals(userCode));

            if (user is null) throw new ArgumentException("Something went wrong");

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.Code = PasswordGenerator.Generate(10, 0);

            dataContext.SaveChanges();
        }

        public void RequestResetPasswordMail(string email)
        {
            var user = FindUserByEmail(email);
            string resetUrl = $"http://localhost:8080/password/reset/{user?.Email ?? "empty"}/{user?.Code ?? "empty"}";

            mailService.SendResetPasswordMail(email, resetUrl);
        }

        public UserDTO GetById(int id) =>
            mapper.Map<UserDTO>(dataContext.Users.Get(id));


        private User FindUserByEmail(string email) =>
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

        private void SendConfirmationMail(string email, string userCode)
        {
            string confirmUrl = $"http://localhost:8080/user-confirmation/{email}/{userCode}";//$"http://localhost:3434/apiForConfirm?token={userCode}"; //TODO: get data from appsettings

            mailService.SendConfirmEmailMail(email, confirmUrl);
        }
    }
}
