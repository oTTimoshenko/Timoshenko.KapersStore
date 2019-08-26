using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UserManagement.Models
{
    public class UserAuthenticateModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
