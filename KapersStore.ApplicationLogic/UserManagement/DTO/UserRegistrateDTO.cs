using KapersStore.Infrastructure.Exceptions;

namespace KapersStore.ApplicationLogic.UserManagement.DTO
{
    public class UserRegistrateDTO
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nickname))
                throw new ValidationException("Nickname is requred", nameof(Nickname));

            if (string.IsNullOrWhiteSpace(Email))
                throw new ValidationException("Email is requred", nameof(Email));

            if (string.IsNullOrWhiteSpace(Password))
                throw new ValidationException("Password is requred", nameof(Password));
        }
    }
}
