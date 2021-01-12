using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPath.Reporting.Domain.Entities
{
    public class IdentityServerPolicy
    {
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
