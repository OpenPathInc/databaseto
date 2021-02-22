using Microsoft.AspNetCore.Identity;
using OpenPath.Reporting.Core.Models;
using System.Linq;

namespace OpenPath.Reporting.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}