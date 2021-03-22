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

namespace api2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperViewAllController : ControllerBase
    {
        private ApplicationDbContext _application;

        public SuperViewAllController(ApplicationDbContext application)
        {
            _application = application;
        }

        [Authorize(Roles = UserRoles.Super)]
        [HttpPost]
        [Route("veiw-all-users")]
        public async Task<IActionResult> ViewAllUsers()
        {
            return View(_application.Users.toList());
        }

    }
}
