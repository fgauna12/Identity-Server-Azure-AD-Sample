namespace Tourney.Authentication.Policies
{
    public interface ICustomAuthenticationPolicy
    {
        bool IsAuthorized();
    }
}