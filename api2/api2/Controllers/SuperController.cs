using api2.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api2.Account;
using System.Linq;
using System;
using System.Collections.Generic;

namespace api2.Controllers
{
    [Authorize(Roles = UserRoles.Super)]
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// This creates the DatabaseToBaseController Class
    /// </summary>
    public class SuperController : DatabaseToBaseController
    {
        private readonly UserManager<Authentication.ApplicationUser> userManager;

        /// <summary>
        /// This is the constructor for the SuperController Class
        /// </summary>
        public SuperController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory
        ) : base(loggerFactory) {
            this.userManager = userManager;
        }

        [Authorize(Roles = UserRoles.Super)]
        [HttpGet]
        [Route("view-all-user-accounts")]
        /// <summary>
        /// This method returns a list that contains all the users.
        /// </summary>
        public List<UserAccount> GetAllUsers()
        {
            Logger.LogInformation("Get request for listing all users");

            List<UserAccount> u = new List<UserAccount>();
            
            var users = userManager.Users;

            foreach(var user in users)
            {
                u.Add(new UserAccount(user.UserName, user.Email));
            }
            
            Logger.LogInformation("Returning list of all users");
            return u;

        }
    }
}
