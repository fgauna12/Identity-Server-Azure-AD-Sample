using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Tourney.Web.Authentication
{
    public static class CustomPolicies
    {
        public const string CanViewFacilities = "CanViewFacilities";

        public static Dictionary<string, IAuthorizationRequirement> Policies 
            = new Dictionary<string, IAuthorizationRequirement>()
            {
                { CanViewFacilities, new CanViewFacilities()}
            };
        
        public static IServiceCollection AddCustomPolicies(this IServiceCollection services)
        {
            services.AddAuthorization((options) =>
            {
                foreach (var customPolicity in Policies)
                {
                    options.AddPolicy(customPolicity.Key, 
                        (policy) => policy.AddRequirements(customPolicity.Value));
                }
            });
            services.AddSingleton<IAuthorizationHandler, CanViewFacilitiesHandler>();
            return services;
        }
    }
}