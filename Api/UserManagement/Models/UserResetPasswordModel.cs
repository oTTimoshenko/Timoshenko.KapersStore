using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UserManagement.Models
{
    public class UserResetPasswordModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }

        public bool Validate() =>
            !string.IsNullOrWhiteSpace(Email)
         && !string.IsNullOrWhiteSpace(Code)
         && !string.IsNullOrWhiteSpace(NewPassword);
    }
}
