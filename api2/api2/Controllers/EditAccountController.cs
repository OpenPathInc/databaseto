﻿using api2.Authentication;
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

namespace api2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// This is the constructor for our EditAccountController Class.
    /// </summary>
    public class EditAccountController : ControllerBase
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
        public EditAccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPut]
        [Route("change-password")]
        /// <summary>
        /// This method changes user's password after authentication.
        /// </summary>
        /// <param name="model">A ChangePasswordModel instance for the ChangePassword function.</param>
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });

            IdentityResult result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "password changed successfully!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "password change fail!" }); ;
        }

        [HttpPut]
        [Route("change-email")]
        /// <summary>
        /// This method changes user's email after authentication.
        /// </summary>
        /// <param name="model">A ChangeEmailModel instance for the ChangeEmail function.</param>
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailModel model)
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });

            IdentityResult result = await userManager.SetEmailAsync(user, model.NewEmail);

            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "email changed successfully!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "password change fail!" }); ;
        }

        [HttpPut]
        [Route("change-username")]
        /// <summary>
        /// This method changes user's username after authentication.
        /// </summary>
        /// <param name="model">A ChangeUsername instance for the ChangeUsername function.</param>
        public async Task<IActionResult> ChangeUsername([FromBody] ChangeUsername model)
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;


            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });

            IdentityResult result = await userManager.SetUserNameAsync(user, model.NewUsername);

            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "username changed successfully!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "password change fail!" }); ;
        }


    }
}
