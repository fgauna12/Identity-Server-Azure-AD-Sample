using System.Collections.Generic;
using IdentityServer4.Models;

namespace Tourney.Identity
{
    public class Identities
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource()
                {
                    Name = "role",
                    Required = true,
                    DisplayName = "Role",
                    Description = "User's role in the system",
                    UserClaims = new List<string>()
                    {
                        "role"
                    }
                }
            };
        }
    }
}