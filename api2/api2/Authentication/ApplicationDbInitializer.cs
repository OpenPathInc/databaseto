using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api2.Authentication {

    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationDbInitializer {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public static void SeedUsers(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        ) {

            Console.WriteLine(userManager.FindByNameAsync("default_super").Result);

            if (userManager.FindByNameAsync("default_super").Result == null) {

                ApplicationUser user = new ApplicationUser {
                    UserName = "default_super",
                    Email = "default_super@databaseto.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var password = generatePassword(userManager);

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded) {

                    Console.WriteLine("Username is default_super");
                    Console.WriteLine("Password is " + password);
                    Console.WriteLine(userManager.GetRolesAsync(user));

                    if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result) {
                        roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    }
                    if (!roleManager.RoleExistsAsync(UserRoles.Super).Result) {
                        roleManager.CreateAsync(new IdentityRole(UserRoles.Super));
                    }

                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <returns></returns>
        private static string generatePassword(UserManager<ApplicationUser> userManager) {

            // setting the base attributes
            var options = userManager.Options.Password;
            var length = options.RequiredLength;
            var nonAlphanumeric = options.RequireNonAlphanumeric;
            var digit = options.RequireDigit;
            var lowercase = options.RequireLowercase;
            var uppercase = options.RequireUppercase;

            // initalizing classes
            var password = new StringBuilder();
            var random = new Random();

            while (password.Length < length) {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }
    }
}
