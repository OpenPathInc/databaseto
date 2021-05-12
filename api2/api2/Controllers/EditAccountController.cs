using api2.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api2.Account;
using Microsoft.Extensions.Logging;

namespace api2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// This is the constructor for our EditAccountController Class.
    /// </summary>
    public class EditAccountController : DatabaseToBaseController
    {
        private readonly UserManager<Authentication.ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// This is the constructor for our EditAccountController Class.
        /// </summary>
        /// <param name="userManager">An instance of Microsoft.AspNetCore.Identity's UserManager class.</param>
        /// <param name="roleManager">An instance of Microsoft.AspNetCore.Identity's RoleManager class.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">An instance that creates a logger.</param>
        public EditAccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILoggerFactory loggerFactory
        ) : base(loggerFactory)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("update")]
        /// <summary>
        /// This method changes user's password after authentication.
        /// </summary>
        /// <param name="model">A Model instance for the updating account information function.</param>
        public async Task<IActionResult> update([FromBody] EditAccountModel model)
        {

            Logger.LogInformation("Get request for updating account information");

            string username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });
            }
            IdentityResult result;
            if (model.NewPassword != null)
            {
                result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            }
            else if (model.NewEmail != null)
            {
                result = await userManager.SetEmailAsync(user, model.NewEmail);
            }
            else if (model.NewUsername != null)
            {
                result = await userManager.SetUserNameAsync(user, model.NewUsername);
            } 
            else
            {
                Logger.LogError("Missing edit account information");
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Missing info to change!" });
            }
            
            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "Account modified successfully!" });
            }

            Logger.LogError("There was a fatal error, soft message returned to user");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Modify account fail!" });

        }


    }
}