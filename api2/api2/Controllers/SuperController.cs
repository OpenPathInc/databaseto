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
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        [Route("users")]
        /// <summary>
        /// This method returns a list that contains all the users.
        /// </summary>
        public IActionResult GetAllUsers()
        {
            Logger.LogInformation("Get request for listing all users");

            int count = Int32.Parse(Request.Query["count"]);

            Console.WriteLine(count);

            int page = Int32.Parse(Request.Query["page"]);

            Console.WriteLine(page);

            var users = userManager.Users;

            int total = users.Count();

            int total_page = total / page + 1;

            if (page > total_page || page == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Page doesn't exists!" });
            }

            var items = users.Skip((page - 1) * count).Take(count).ToList();

            var last_page_url = "no last page";


            if (page > 1)
            {
                last_page_url = "https://localhost:44353/api/super/users?count="+ count + "&page=" + (page - 1);
            }

            var next_page_url = "no next page";

            if (page < total_page)
            {
                next_page_url = "https://localhost:44353/api/super/users?count="+count+"&page=" + (page + 1);
            }

            Logger.LogInformation("Returning list of all users");

            return Ok(new Payload
            {
                Version = "0.1",
                count = count,
                page = page,
                total = total,

                last_page = last_page_url,

                next_page = next_page_url,

                results = items,




            });
        }

    }
}
