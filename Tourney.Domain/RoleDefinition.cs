namespace Tourney.Domain
{
    public class RoleDefinition
    {
        public RoleDefinition(string displayName, string claimValue)
        {
            DisplayName = displayName;
            ClaimValue = claimValue;
        }

        public string DisplayName { get; set; }
        public string ClaimValue { get; set; }
    }
}