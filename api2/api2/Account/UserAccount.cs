using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Account
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public UserAccount(String username, String email)
        {
            Username = username;
            Email = email;
        }
    }
}
