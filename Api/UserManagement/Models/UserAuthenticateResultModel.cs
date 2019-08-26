namespace Api.UserManagement.Models
{
    public class UserAuthenticateResultModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
