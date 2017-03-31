using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Tourney.Identity
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "api" ,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())    
                    },
                    AllowedScopes = new List<string>()
                    {
                        "dealerApi"
                    },
                    ClientName = "Tourney API",
                    AccessTokenType = AccessTokenType.Jwt
                },
                new Client
                {
                    ClientId = "js",
                    ClientName = "Sample App",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5003/callback" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5003" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "dealerApi",
                        "custom.profile"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}