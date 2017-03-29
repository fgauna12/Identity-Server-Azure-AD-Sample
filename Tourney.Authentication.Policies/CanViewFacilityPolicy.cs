using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation;
using IdentityModel;
using Tourney.Domain;

namespace Tourney.Authentication.Policies
{
    public class CanViewFacilityAccessValidator : AbstractValidator<ClaimsPrincipal>
    {
        public CanViewFacilityAccessValidator()
        {
            RuleFor(customer => customer.Claims).NotEmpty();
            RuleFor(customer => customer.Claims)
                .Must(BeAuthorized)
                .WithMessage("Unauthorizer. Your role does not have enough permissions");
        }

        private bool BeAuthorized(IEnumerable<Claim> arg)
        {
            var roles = arg.Where(x => x.Type == JwtClaimTypes.Role);
            return roles.Any(x => x.Value == Roles.FacilityAdmin.ClaimValue || x.Value == Roles.Developer.ClaimValue);
        }
    }
}
