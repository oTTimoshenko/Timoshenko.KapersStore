using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UserManagement.Models
{
    public class UserConfirmEmailModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
