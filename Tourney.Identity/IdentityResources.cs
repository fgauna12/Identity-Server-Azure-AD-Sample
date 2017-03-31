using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Tourney.Identity
{
    public class Identities
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var claims = new[] {JwtClaimTypes.Role, JwtClaimTypes.Id, JwtClaimTypes.Subject};
            var customProfile = new IdentityResource(
            name: "custom.profile",
            displayName: "Role",
            claimTypes: claims)
            {
                Description = "Your role in the organization",
                Required = true,
                UserClaims = claims
            };
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                customProfile
            };
        }
    }
}