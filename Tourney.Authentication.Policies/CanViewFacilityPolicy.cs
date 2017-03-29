
using System.Security.Claims;
using System.Threading.Tasks;
using Tourney.Domain;

namespace Tourney.Authentication.Policies
{
    public class CanViewFacilityPolicy : ICustomAuthenticationPolicy
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public CanViewFacilityPolicy(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        public bool IsAuthorized()
        {
            //Is facility or developer
            if (_claimsPrincipal.IsInRole(Roles.FacilityAdmin.ClaimValue)
                || _claimsPrincipal.IsInRole(Roles.Developer.ClaimValue))
            {
                return true;
            }

            return false;
        }
    }
}
