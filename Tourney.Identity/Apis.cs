using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Tourney.Identity
{
    public class Apis
    {
        public static IEnumerable<ApiResource> Get()
        {
            return new List<ApiResource>()
            {
                new ApiResource("dealerApi", "Dealer API")
                {
                    UserClaims = new List<string>()
                    {
                        JwtClaimTypes.Role
                    }
                },
            };
        }
    }
}