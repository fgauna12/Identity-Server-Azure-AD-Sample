using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Tourney.Authentication.Policies;

namespace Tourney.Web.Authentication
{
    public class CanViewFacilitiesHandler : AuthorizationHandler<CanViewFacilities>
    {
        private readonly ILogger<CanViewFacilitiesHandler> _logger;

        public CanViewFacilitiesHandler(ILogger<CanViewFacilitiesHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanViewFacilities requirement)
        {
            var canViewFacilityPolicy = new CanViewFacilityAccessValidator();
            var canAccess = canViewFacilityPolicy.Validate(context.User);
            if (!canAccess.IsValid)
            {
                _logger.LogWarning(
                    $"User is not authorized. " +
                    $"Failed {GetType().Name} policy. " +
                    $"{Environment.NewLine}Errors => {string.Join(Environment.NewLine, canAccess.Errors.Select(x => x.ErrorMessage))}");
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}