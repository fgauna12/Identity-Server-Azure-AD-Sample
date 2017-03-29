namespace Tourney.Domain
{
    public static class Roles
    {
        public static RoleDefinition Developer 
            = new RoleDefinition("Developer", "Developer");

        public static RoleDefinition OrganizationAdmin 
            = new RoleDefinition("Organization Administrator", "OrganizationAdmin");

        public static RoleDefinition FacilityAdmin 
            = new RoleDefinition("Facility Administrator", "FacilityAdmin");
    }

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