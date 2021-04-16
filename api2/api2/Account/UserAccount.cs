using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Account {

    /// <summary>
    /// This class is used to manage the users name and email.
    /// </summary>
    public class UserAccount {

        /// <summary>
        /// This is the users account username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// This is the users email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// This initates the user account with their username and email.
        /// </summary>
        /// <param name="username">The users Username.</param>
        /// <param name="email">The users email address.</param>
        public UserAccount(String username, String email) {
            Username = username;
            Email = email;
        }

    }

}
