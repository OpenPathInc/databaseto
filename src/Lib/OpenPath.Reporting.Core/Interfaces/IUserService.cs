using OpenPath.Reporting.Core.Models;
using OpenPath.Reporting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPath.Reporting.Core.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
