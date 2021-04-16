using api2.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// This initates the AuthenticateController Class
    /// </summary>
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        /// <summary>
        /// This is the constructor for our AuthenticateController Class.
        /// </summary>
        /// <param name="userManager">An instance of Microsoft.AspNetCore.Identity's UserManager class.</param>
        /// <param name="roleManager">An instance of Microsoft.AspNetCore.Identity's RoleManager class.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">An instance that creates a logger.</param>
        public AuthenticateController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILoggerFactory loggerFactory
        ) {

            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<AuthenticateController>();

            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("login")]
        /// <summary>
        /// This authenticates the login function for our users.
        /// </summary>
        /// <param name="model">The LoginModel instance for login fucntion</param>
        public async Task<IActionResult> Login([FromBody] LoginModel model) {

            // we need some validation before executing...


            _logger.LogInformation($"Authenticating user: {model.Username}");

            var user = await userManager.FindByNameAsync(model.Username);
            if (!await roleManager.RoleExistsAsync(UserRoles.Super))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Super));
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (model.Username == "default_super" && await roleManager.RoleExistsAsync(UserRoles.Super))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Super);
                Console.WriteLine("default_super login");
            }

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [Authorize(Roles = UserRoles.Super)]
        [HttpPost]
        [Route("register-admin")]
        /// <summary>
        /// This autehnticates the create Admin User function.
        /// </summary>
        /// <param name="model">The RegisterModel instance for create Admin User function.</param>
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Super))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Super));
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "Admin User created successfully!" });
        }

        [Authorize(Roles = UserRoles.Super)]
        [HttpPost]
        [Route("register-super")]
        /// <summary>
        /// This autehnticates the create Super User function.
        /// </summary>
        /// <param name="model">The RegisterModel instance for create Super User function.</param>
        public async Task<IActionResult> RegisterSuper([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Super))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Super));
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await roleManager.RoleExistsAsync(UserRoles.Super))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Super);
            }

            return Ok(new Response { Status = "Success", Message = "Super User created successfully!" });
        }
    }
}