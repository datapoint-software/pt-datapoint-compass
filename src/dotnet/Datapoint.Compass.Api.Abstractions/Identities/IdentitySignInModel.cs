namespace Datapoint.Compass.Api.Identities
{
    public sealed class IdentitySignInModel
    {
        public IdentitySignInModel(string emailAddress, string password, bool rememberMe)
        {
            EmailAddress = emailAddress;
            Password = password;
            RememberMe = rememberMe;
        }

        public string EmailAddress { get; }

        public string Password { get; }

        public bool RememberMe { get; }
    }
}
