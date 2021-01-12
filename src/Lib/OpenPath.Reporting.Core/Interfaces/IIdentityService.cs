using OpenPath.Reporting.Core.Models;
using OpenPath.Reporting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenPath.Reporting.Core.Interfaces
{
    public interface IIdentityService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);

        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
