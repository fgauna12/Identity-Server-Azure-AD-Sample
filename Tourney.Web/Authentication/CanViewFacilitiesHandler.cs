using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Tourney.Authentication.Policies;

namespace Tourney.Web.Authentication
{
    public class CanViewFacilitiesHandler : AuthorizationHandler<CanViewFacilities>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanViewFacilities requirement)
        {
            var canViewFacilityPolicy = new CanViewFacilityPolicy(context.User);
            if (!canViewFacilityPolicy.IsAuthorized())
            {
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}