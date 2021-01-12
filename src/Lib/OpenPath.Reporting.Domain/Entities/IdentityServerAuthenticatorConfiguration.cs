using System.Collections.Generic;


namespace OpenPath.Reporting.Domain.Entities
{
    public class IdentityServerAuthenticatorConfiguration : IConfiguration
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Server { get; set; }
        public List<string> Scopes { get; set; }
        public List<IdentityServerPolicy> Policies { get; set; }
    }
}
